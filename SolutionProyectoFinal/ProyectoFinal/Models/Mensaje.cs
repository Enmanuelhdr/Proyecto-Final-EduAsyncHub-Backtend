using System;
using System.Collections.Generic;

namespace ProyectoFinal.Models
{
    public partial class Mensaje
    {
        public int MensajeId { get; set; }
        public int UsuarioId { get; set; }
        public string Mensaje1 { get; set; } = null!;
        public DateTime? FechaEnvio { get; set; }
        public int? SeccionId { get; set; }

        public virtual Usuario Usuario { get; set; } = null!;
    }
}
