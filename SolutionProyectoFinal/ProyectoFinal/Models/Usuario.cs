using System;
using System.Collections.Generic;

namespace ProyectoFinal.Models
{
    public partial class Usuario
    {
        public string UsuarioId { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string CorreoElectronico { get; set; } = null!;
        public string Contraseña { get; set; } = null!;
        public int? RolId { get; set; }

        public virtual Role? Rol { get; set; }
        public virtual Estudiante? Estudiante { get; set; }
        public virtual Profesore? Profesore { get; set; }
    }
}
