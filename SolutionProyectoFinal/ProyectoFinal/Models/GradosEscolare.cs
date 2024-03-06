using System;
using System.Collections.Generic;

namespace ProyectoFinal.Models
{
    public partial class GradosEscolare
    {
        public GradosEscolare()
        {
            EstudianteMateria = new HashSet<EstudianteMaterium>();
            Estudiantes = new HashSet<Estudiante>();
            ProfesorMateria = new HashSet<ProfesorMaterium>();
        }

        public int GradoId { get; set; }
        public string NombreGrado { get; set; } = null!;

        public virtual ICollection<EstudianteMaterium> EstudianteMateria { get; set; }
        public virtual ICollection<Estudiante> Estudiantes { get; set; }
        public virtual ICollection<ProfesorMaterium> ProfesorMateria { get; set; }
    }
}
