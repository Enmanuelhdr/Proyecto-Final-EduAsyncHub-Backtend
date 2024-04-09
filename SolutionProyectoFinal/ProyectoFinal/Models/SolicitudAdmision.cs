using System;
using System.Collections.Generic;

namespace ProyectoFinal.Models
{
    public partial class SolicitudAdmision
    {
        public int SolicitudId { get; set; }
        public string? NombreEstudiante { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? Genero { get; set; }
        public string? DireccionEstudiante { get; set; }
        public int Grado { get; set; }
        public string? EscuelaActual { get; set; }
        public string? NombrePadreTutor { get; set; }
        public string? RelacionEstudiante { get; set; }
        public string? DireccionPadreTutor { get; set; }
        public string? NumeroTelefono { get; set; }
        public string? CorreoElectronico { get; set; }
        public DateTime? FechaHoraSolicitud { get; set; }
        public string? EstadoSolicitud { get; set; }
        public string? NotasComentarios { get; set; }
    }
}
