using System;
using System.Collections.Generic;
using System.Text;

namespace MonitorProcesos.Entidad.Modelo
{
    public class Conector
    {
        public int ConectorId { get; set; }
        public DateTime FechaOcurrencia { get; set; }
        public int ConectorConfiguracionId { get; set; }

        public int SistemaId { get; set; }
        public string SistemaDescripcion { get; set; }
        public string ConectorConfiguracionDescripcion { get; set; }
        public int Alertas { get; set; }
        public int Errores { get; set; }
        public int? Eventos { get; set; }
    }
}
