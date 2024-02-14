using System;
using System.Collections.Generic;

namespace ProyectoFinal.Models
{
    public partial class UsuariosCurso
    {
        public int UsuarioCursoId { get; set; }
        public int? UserId { get; set; }
        public int? CursoId { get; set; }

        public virtual Curso? Curso { get; set; }
        public virtual Usuario? User { get; set; }
    }
}
