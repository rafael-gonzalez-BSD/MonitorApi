using System;

namespace MonitorProcesos.Entidad.Modelo
{
    public class Sistema
    {
        public int SistemaId { get; set; }

        public string SistemaDescripcion { get; set; }

        public string Alias { get; set; }

        public string Descripcion { get; set; }

        public int UsuarioCreacionId { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int UsuarioModificacionId { get; set; }

        public DateTime FechaModificacion { get; set; }

        public int? UsuarioBajaId { get; set; }

        public DateTime? FechaBaja { get; set; }

        public bool Baja { get; set; }

        public int GerenciaId { get; set; }

        public string GerenciaDescripcion { get; set; }
        public int Opcion { get; set; }
    }
}