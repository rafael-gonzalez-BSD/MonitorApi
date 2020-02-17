
using System;
using System.Collections.Generic;
using System.Text;

namespace MonitorProcesos.Entidad.Modelo
{
    public class Ejecucion
    {
        public int EjecucionId { get; set; }
        public DateTime FechaOcurrencia { get; set; }
        public string Servidor { get; set; }
        public int ProcesoId { get; set; }
        public int SistemaId { get; set; }
        public string SistemaDescripcion { get; set; }
        public string ProcesoDescripcion { get; set; }
        public int Alertas { get; set; }
        public int Eventos { get; set; }
    }
}
