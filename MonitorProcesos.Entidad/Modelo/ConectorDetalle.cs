using System;
using System.Collections.Generic;
using System.Text;

namespace MonitorProcesos.Entidad.Modelo
{
    public class ConectorDetalle
    {
        public int ConectorDetalleId { get; set; }
        public string ConectorDetalleDescripcion { get; set; }
        public DateTime FechaOcurrencia { get; set; }
        public string AlertaDescripcion { get; set; }
        public bool EjecucionSatisfactoria { get; set; }
        public int ConectorDetalleRespuestaId { get; set; }
        public int ConectorId { get; set; }

        public int SistemaId { get; set; }
        public string SistemaDescripcion { get; set; }
        public int ConectorConfiguracionId { get; set; }
        public string ConectorConfiguracionDescripcion { get; set; }
        public string ConectorDetalleRespuestaDescripcion { get; set; }
    }
}
