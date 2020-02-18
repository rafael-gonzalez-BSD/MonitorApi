using System;
using System.Collections.Generic;
using System.Text;

namespace MonitorProcesos.Entidad.Modelo
{
    public class EjecucionDetalle
    {
        public int EjecucionDetalleId { get; set; }
        public string EjecucionDetalleDescripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public int EjecucionTipoId { get; set; }
        public int EjecucionAlertaId { get; set; }
        public int EjecucionId { get; set; }

        public int SistemaId { get; set; }
        public string SistemaDescripcion { get; set; }
        public int ProcesoId { get; set; }
        public string ProcesoDescripcion { get; set; }
        public string Servidor { get; set; }
        public int? TiempoEstimadoEjecucion { get; set; }
        public int? TiempoOptimoEjecucion { get; set; }
        public int? TiempoEjecucion { get; set; }
    }
}
