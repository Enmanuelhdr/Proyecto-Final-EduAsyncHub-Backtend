using System;
using System.Collections.Generic;

namespace ProyectoFinal.Models
{
    public partial class Carrera
    {
        public Carrera()
        {
            Estudiantes = new HashSet<Estudiante>();
            Materia = new HashSet<Materia>();
        }

        public int CarreraId { get; set; }
        public string NombreCarrera { get; set; } = null!;

        public virtual ICollection<Estudiante> Estudiantes { get; set; }

        public virtual ICollection<Materia> Materia { get; set; }
    }
}
