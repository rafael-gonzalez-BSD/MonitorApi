using System;
using System.Collections.Generic;
using System.Text;

namespace MonitorProcesos.Entidad.Modelo
{
    public class ExcepcionDetalle
    {
        public int ExcepcionDetalleId { get; set; }
        public string Error { get; set; }
        public string Pagina { get; set; }
        public string LogText { get; set; }        
        public DateTime FechaOcurrencia { get; set; }

        public int SistemaId { get; set; }
        public string SistemaDescripcion { get; set; }
        public string Servidor { get; set; }        
        public string ErrorNumero { get; set; }
        public string ErrorDescripcion { get; set; }


    }
}
