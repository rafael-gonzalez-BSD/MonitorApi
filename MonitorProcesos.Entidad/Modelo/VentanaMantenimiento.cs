using System;
using System.Collections.Generic;
using System.Text;

namespace MonitorProcesos.Entidad.Modelo
{
    public class VentanaMantenimiento
    {
        public int VentanaMantenimientoId { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public int UsuarioCreacionId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int UsuarioModificacionId { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int UsuarioBajaId { get; set; }
        public DateTime FechaBaja { get; set; }
        public bool Baja { get; set; }
        public int SistemaId { get; set; }

        //Propiedades de tablas externas
        public string SistemaDescripcion { get; set; }

        //Campo requerido por la opción en el stored
        public int Opcion { get; set; }
    }
}
