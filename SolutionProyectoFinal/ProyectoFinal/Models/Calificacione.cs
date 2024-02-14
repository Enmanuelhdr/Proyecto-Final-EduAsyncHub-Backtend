using System;
using System.Collections.Generic;

namespace ProyectoFinal.Models
{
    public partial class Calificacione
    {
        public int CalificacionId { get; set; }
        public decimal? ValorCalificacion { get; set; }
        public string? TipoEvaluacion { get; set; }
        public string? PeriodoEvaluacion { get; set; }
        public int? UserId { get; set; }
        public int? CursoId { get; set; }

        public virtual Curso? Curso { get; set; }
        public virtual Usuario? User { get; set; }
    }
}
