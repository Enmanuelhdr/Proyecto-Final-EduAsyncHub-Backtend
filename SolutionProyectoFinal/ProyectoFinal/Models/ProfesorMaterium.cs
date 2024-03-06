using System;
using System.Collections.Generic;

namespace ProyectoFinal.Models
{
    public partial class ProfesorMaterium
    {
        public int AsignacionProfesorId { get; set; }
        public int? ProfesorId { get; set; }
        public int? MateriaId { get; set; }
        public int? GradoId { get; set; }

        public virtual GradosEscolare? Grado { get; set; }
        public virtual Materia? Materia { get; set; }
        public virtual Profesore? Profesor { get; set; }
    }
}
