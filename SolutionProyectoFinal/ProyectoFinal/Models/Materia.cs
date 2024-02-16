using System;
using System.Collections.Generic;

namespace ProyectoFinal.Models
{
    public partial class Materia
    {
        public Materia()
        {
            Asignaciones = new HashSet<Asignacione>();
            Asistencia = new HashSet<Asistencium>();
            Calificaciones = new HashSet<Calificacione>();
            Carreras = new HashSet<Carrera>();
            Estudiantes = new HashSet<Estudiante>();
            Profesors = new HashSet<Profesore>();
        }

        public int MateriaId { get; set; }
        public string NombreMateria { get; set; } = null!;

        public virtual ICollection<Asignacione> Asignaciones { get; set; }
        public virtual ICollection<Asistencium> Asistencia { get; set; }
        public virtual ICollection<Calificacione> Calificaciones { get; set; }

        public virtual ICollection<Carrera> Carreras { get; set; }
        public virtual ICollection<Estudiante> Estudiantes { get; set; }
        public virtual ICollection<Profesore> Profesors { get; set; }
    }
}
