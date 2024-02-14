using System;
using System.Collections.Generic;

namespace ProyectoFinal.Models
{
    public partial class Curso
    {
        public Curso()
        {
            Asistencia = new HashSet<Asistencium>();
            Calificaciones = new HashSet<Calificacione>();
            Mensajes = new HashSet<Mensaje>();
            UsuariosCursos = new HashSet<UsuariosCurso>();
        }

        public int CursoId { get; set; }
        public string? NombreCurso { get; set; }
        public string? DescripcionCurso { get; set; }

        public virtual ICollection<Asistencium> Asistencia { get; set; }
        public virtual ICollection<Calificacione> Calificaciones { get; set; }
        public virtual ICollection<Mensaje> Mensajes { get; set; }
        public virtual ICollection<UsuariosCurso> UsuariosCursos { get; set; }
    }
}
