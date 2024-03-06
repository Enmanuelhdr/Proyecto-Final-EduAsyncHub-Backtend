using System;
using System.Collections.Generic;

namespace ProyectoFinal.Models
{
    public partial class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nombre { get; set; } = null!;
        public string CorreoElectronico { get; set; } = null!;
        public string Contraseña { get; set; } = null!;
        public string? FotoPerfil { get; set; }
        public string? DescripcionBreve { get; set; }
        public string? Intereses { get; set; }
        public string? Habilidades { get; set; }
        public int? RolId { get; set; }

        public virtual Role? Rol { get; set; }
        public virtual Estudiante? Estudiante { get; set; }
        public virtual Profesore? Profesore { get; set; }
    }
}
