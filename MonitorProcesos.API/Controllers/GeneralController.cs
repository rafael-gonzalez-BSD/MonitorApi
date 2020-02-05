using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MonitorProcesos.Entidad.Base;
using MonitorProcesos.Negocio;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MonitorProcesos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralController : ControllerBase
    {
        private readonly MonitorConfiguracionNegocio n;

        public GeneralController(IConfiguration config)
        {
            n = new MonitorConfiguracionNegocio(config, "MonitorRemoteDev");
        }
        [HttpGet("testRutaApi")]
        public RespuestaPeticionModel TestearRutaApi()
        {
            return new RespuestaPeticionModel
            {
                Clave = 1,
                Valor = "Éxito",
                Descripcion = ""
            };
        }

        [HttpGet("testRutaArchivos")]
        public RespuestaModel TestearRutaArchivos(string RutaLog)
        {
            RespuestaModel res = new RespuestaModel();
            string ip = @"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}";
            string pattern = string.Format(@"^[A-Z]:(\\(\w+\s*)+)+" + // filename
                             @"|^\\\\{0}(\\(\w+\s*)+)+" +              // url with ip
                             @"|^\\(\\(\w+\s*)+)+" +                   // network filename \\abc\def
                             @"|^FTP://{0}/" +                         // ftp with ip
                             @"|^FTP://[A-Z]\w+/", ip);                // ftp with hostname


            try
            {
                bool existe = false;
                if (RutaLog.Substring(0, 7) == "http://" || RutaLog.Substring(0, 8) == "https://") {
                    existe = Utils.FileSystemScanner.UrlDirectoryExist(RutaLog);
                }

                if (Regex.IsMatch(RutaLog, pattern, RegexOptions.IgnoreCase))
                {
                    existe = Utils.FileSystemScanner.PathDirectoryExist(RutaLog);
                }
                

                if (existe)
                {
                    res.Datos = null;
                    res.ErrorId = 0;
                    res.Id = 0;
                    res.Mensaje = "El directorio si existe";
                    res.Satisfactorio = true;
                }
                else
                {
                    res.Datos = null;
                    res.ErrorId = 404;
                    res.Id = 0;
                    res.Mensaje = "El directorio no existe";
                    res.Satisfactorio = false;
                }
            }
            catch (Exception ex)
            {
                res.Datos = null;
                res.ErrorId = 500;
                res.Id = 0;
                res.Mensaje = "Error interno del sistema. " + ex.Message + ": " + ex.InnerException?.ToString();
                res.Satisfactorio = false;
            }

            return res;
        }

        [HttpGet("obtenerConfiguracion")]
        public async Task<RespuestaModel> ObtenerConfiguracion(int Identificador) {
            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                {"Identificador", Identificador }
            };
            return await n.ObtenerConfiguracion(param);
        }
    }
}