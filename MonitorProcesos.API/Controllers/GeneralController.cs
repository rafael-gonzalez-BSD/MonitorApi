using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MonitorProcesos.Entidad.Base;
using MonitorProcesos.Negocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
                if (RutaLog.Length > 8 && (RutaLog.Substring(0, 7) == "http://" || RutaLog.Substring(0, 8) == "https://"))
                {
                    List<string> files = Utils.FileSystemScanner.UrlDirectoryExist(RutaLog, out mensaje);
                    if (files.Count > 0)
                    {
                        foreach (string filename in files.Where(x => x.Contains(".txt")))
                        {
                            string[] filenameArray = filename.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
                            if (filenameArray[filenameArray.Length - 1].Contains("LogExec.txt") || filenameArray[filenameArray.Length - 1].Contains("LogEjec.txt"))
                            {
                                string urlFile = Path.Combine(RutaLog, filenameArray[filenameArray.Length - 1]);
                                bool canRead = Utils.FileSystemScanner.GetLogFile(urlFile, out string mensajeArchivo);
                                existe = canRead;
                                mensaje = mensajeArchivo;
                                break;
                            }
                            else
                            {
                                existe = false;
                                mensaje = "No se pudo leer el archivo con los permisos.";
                            }
                        }
                    }
                }

                if (Regex.IsMatch(RutaLog, pattern, RegexOptions.IgnoreCase))
                {
                    existe = Utils.FileSystemScanner.PathDirectoryExist(RutaLog);
                }

                res.Datos = null;
                res.ErrorId = existe ? 0 : 404;
                res.Id = 0;
                res.Mensaje = existe ? "La ruta si existe" : mensaje.Length > 0 ? mensaje : "La ruta es invalida";
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