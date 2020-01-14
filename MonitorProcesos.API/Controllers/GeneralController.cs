using Microsoft.AspNetCore.Mvc;
using MonitorProcesos.Entidad.Base;
using System;
using System.Net.NetworkInformation;

namespace MonitorProcesos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralController : ControllerBase
    {
        [HttpGet("testRutaApi")]
        public RespuestaModel TestearRutaApi(string urlApi)
        {
            RespuestaModel res = new RespuestaModel();

            try
            {
                Uri uri = new Uri(urlApi);
                Ping ping = new Ping();
                PingReply result = ping.Send(uri.Host);

                if (result.Status == IPStatus.Success)
                {
                    res.Datos = null;
                    res.ErrorId = 0;
                    res.Id = 0;
                    res.Mensaje = "Ping Satisfactorio";
                    res.Satisfactorio = true;
                }
                else
                {
                    res.Datos = null;
                    res.ErrorId = 404;
                    res.Id = 0;
                    res.Mensaje = "Error al hacer ping";
                    res.Satisfactorio = false;
                }
            }
            catch (Exception ex)
            {

                res.Datos = null;
                res.ErrorId = 500;
                res.Id = 0;
                res.Mensaje = "Error interno del sistema. " + ex.Message + ": " + ex.InnerException.ToString();
                res.Satisfactorio = false;
            }



            return res;
        }

        [HttpGet("testRutaArchivos")]
        public RespuestaModel TestearRutaArchivos(string url)
        {
            RespuestaModel res = new RespuestaModel();
            
            try
            {
                bool existe = Utils.FileSystemScanner.UrlDirectoryExist(url);
                //bool prueba2 = Utils.FileSystemScanner.UrlDirectoryDownload(url);

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
                res.Mensaje = "Error interno del sistema. " + ex.Message + ": " + ex.InnerException.ToString();
                res.Satisfactorio = false;
            }

            return res;
        }
    }
}