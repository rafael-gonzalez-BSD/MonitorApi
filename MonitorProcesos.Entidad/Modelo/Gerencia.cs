using System;

namespace MonitorProcesos.Entidad.Modelo
{
    public class Gerencia
    {
        public int GerenciaId { get; set; }

        public string GerenciaDescripcion { get; set; }

        public int UsuarioCreacionId { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int UsuarioModificacionId { get; set; }

        public DateTime FechaModificacion { get; set; }

        public int? UsuarioBajaId { get; set; }

        public DateTime? FechaBaja { get; set; }

        public bool Baja { get; set; }

        public int? RegistroId { get; set; }
    }
}