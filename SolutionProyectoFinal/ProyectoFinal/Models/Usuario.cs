using System;
using System.Collections.Generic;

namespace ProyectoFinal.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Asistencia = new HashSet<Asistencium>();
            Calificaciones = new HashSet<Calificacione>();
            Mensajes = new HashSet<Mensaje>();
            UsuariosCursos = new HashSet<UsuariosCurso>();
        }

        public int UserId { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? Contraseña { get; set; }
        public string? Rol { get; set; }

        public virtual ICollection<Asistencium> Asistencia { get; set; }
        public virtual ICollection<Calificacione> Calificaciones { get; set; }
        public virtual ICollection<Mensaje> Mensajes { get; set; }
        public virtual ICollection<UsuariosCurso> UsuariosCursos { get; set; }
    }
}
