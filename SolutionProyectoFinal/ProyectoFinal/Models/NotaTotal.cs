using System;
using System.Collections.Generic;

namespace ProyectoFinal.Models
{
    public partial class NotaTotal
    {
        public int NotaTotalId { get; set; }
        public int? EstudianteId { get; set; }
        public int? MateriaId { get; set; }
        public double? NotaTotal1 { get; set; }

        public virtual Estudiante? Estudiante { get; set; }
        public virtual Materia? Materia { get; set; }
    }
}
