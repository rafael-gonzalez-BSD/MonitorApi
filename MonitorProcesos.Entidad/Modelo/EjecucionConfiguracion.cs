using System;

namespace MonitorProcesos.Entidad.Modelo
{
    public class EjecucionConfiguracion
    {
        public int EjecucionConfiguracionId { get; set; }

        public short Frecuencia { get; set; }

        public TimeSpan HoraDesde { get; set; }

        public TimeSpan HoraHasta { get; set; }

        public string RutaLog { get; set; }

        public short TiempoEstimadoEjecucion { get; set; }

        public short TiempoOptimoEjecucion { get; set; }

        public int UsuarioCreacionId { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int UsuarioModificacionId { get; set; }

        public DateTime FechaModificacion { get; set; }

        public int? UsuarioBajaId { get; set; }

        public DateTime? FechaBaja { get; set; }

        public bool Baja { get; set; }

        public int SistemaId { get; set; }

        public string SistemaDescripcion { get; set; }

        public int ProcesoId { get; set; }

        public string ProcesoDescripcion { get; set; }

        public int Opcion { get; set; }
    }
}