using System;
using System.Collections.Generic;

namespace ProyectoFinal.Models
{
    public partial class Estudiante
    {
        public Estudiante()
        {
            Asistencia = new HashSet<Asistencia>();
            Calificaciones = new HashSet<Calificacione>();
            EstudianteMateria = new HashSet<EstudianteMaterium>();
        }

        public int EstudianteId { get; set; }
        public string? UsuarioId { get; set; }
        public int? GradoId { get; set; }

        public virtual GradosEscolare? Grado { get; set; }
        public virtual Usuario? Usuario { get; set; }
        public virtual NotaTotal? NotaTotal { get; set; }
        public virtual ICollection<Asistencia> Asistencia { get; set; }
        public virtual ICollection<Calificacione> Calificaciones { get; set; }
        public virtual ICollection<EstudianteMaterium> EstudianteMateria { get; set; }
    }
}
