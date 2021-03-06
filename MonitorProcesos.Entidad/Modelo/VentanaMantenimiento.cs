﻿using System;

namespace MonitorProcesos.Entidad.Modelo
{
    public class VentanaMantenimiento
    {
        public int VentanaMantenimientoId { get; set; }

        public DateTime FechaDesde { get; set; }

        public TimeSpan HoraDesde { get; set; }

        public DateTime FechaHasta { get; set; }

        public TimeSpan HoraHasta { get; set; }

        public int UsuarioCreacionId { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int UsuarioModificacionId { get; set; }

        public DateTime FechaModificacion { get; set; }

        public int? UsuarioBajaId { get; set; }

        public DateTime? FechaBaja { get; set; }

        public bool Baja { get; set; }

        public int SistemaId { get; set; }

        public string SistemaDescripcion { get; set; }

        public int Opcion { get; set; }
    }
}