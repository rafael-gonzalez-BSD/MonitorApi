using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MonitorProcesos.Entidad.Base;
using MonitorProcesos.Negocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
                Descripcion = "Se realizó el ping a la API exitosamente"
            };
        }

        [HttpGet("testRutaApi2")]
        public RespuestaPeticionModel TestearRutaApi2()
        {
            return new RespuestaPeticionModel
            {
                Clave = 2,
                Valor = "Error",
                Descripcion = "Error al realizar la peticion al API"
            };
        }

        [HttpGet("testRutaApi3")]
        public RespuestaPeticionModel TestearRutaApi3()
        {
            return new RespuestaPeticionModel
            {
                Clave = 3,
                Valor = "Alerta",
                Descripcion = "Mesaje de prueba de Alerta "
            };
        }

        [HttpGet("testRutaArchivos")]
        public RespuestaModel TestearRutaArchivos(string RutaLog, string ArchivoTest)
        {
            string mensaje = "";
            RespuestaModel res = new RespuestaModel();
            string ip = @"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}";
            string pattern = string.Format(@"^[A-Z]:(\\(\w+\s*)+)+" +
                             @"|^\\\\{0}(\\(\w+\s*)+)+" +
                             @"|^\\(\\(\w+\s*)+)+" +
                             @"|^FTP://{0}/" +
                             @"|^FTP://[A-Z]\w+/", ip);

            try
            {
                bool existe = false;
                List<string> files;
                string[] filenameArray;
                if (RutaLog.Length > 8 && (RutaLog.Substring(0, 7) == "http://" || RutaLog.Substring(0, 8) == "https://"))
                {                    
                    files = Utils.FileSystemScanner.UrlDirectoryExist(RutaLog, out mensaje);
                    if (files.Count > 0)
                    {
                        foreach (string filename in files.Where(x => x.Contains(".txt")))
                        {
                            filenameArray = filename.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
                            if (filenameArray[filenameArray.Length - 1].Contains(ArchivoTest))
                            {
                                string urlFile = Path.Combine(RutaLog, filenameArray[filenameArray.Length - 1]);
                                existe = Utils.FileSystemScanner.GetLogFile(urlFile, 2,out mensaje);                                
                                break;
                            }
                            else
                            {
                                existe = false;
                                mensaje = "No se encontró el archivo de Test";
                            }
                        }
                    }
                }

                if (Regex.IsMatch(RutaLog, pattern, RegexOptions.IgnoreCase))
                {
                    files = Utils.FileSystemScanner.PathDirectoryExist(RutaLog, out mensaje);

                    if (files.Count > 0)
                    {
                        foreach (string filename in files.Where(x =>x.Contains(".txt")))
                        {
                            filenameArray = filename.Split(new string[] { @"\" }, StringSplitOptions.RemoveEmptyEntries);
                            if (filenameArray[filenameArray.Length - 1].Contains(ArchivoTest))
                            {                                
                                existe = Utils.FileSystemScanner.GetLogFile(filename, 1, out mensaje);
                                break;
                            }
                            else
                            {
                                existe = false;
                                mensaje = "No se encontró el archivo de Test";
                            }
                        }
                    }
                }

                res.Datos = null;
                res.ErrorId = existe ? 0 : 404;
                res.Id = 0;
                res.Mensaje = existe ? "Ruta Log Exitosa" : mensaje.Length > 0 ? mensaje : "La ruta es invalida";
                res.Satisfactorio = existe;
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
        public async Task<RespuestaModel> ObtenerConfiguracion(int Identificador)
        {
            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                {"Identificador", Identificador }
            };
            return await n.ObtenerConfiguracion(param);
        }
    }
}