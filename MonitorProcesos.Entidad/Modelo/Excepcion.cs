using System;
using System.Collections.Generic;
using System.Text;

namespace MonitorProcesos.Entidad.Modelo
{
    public class Excepcion
    {
        public int ExcepcionId { get; set; }
        public string SistemaDescripcion { get; set; }
        public DateTime FechaOcurrencia { get; set; }
        public string Servidor { get; set; }
        public string Error { get; set; }
        public string ErrorNumero { get; set; }
        public string ErrorDescripcion { get; set; }
        public int ExcepcionEstatusId { get; set; }
        public string ExcepcionEstatusDescripcion { get; set; }
        public int Eventos { get; set; }
    }
}
