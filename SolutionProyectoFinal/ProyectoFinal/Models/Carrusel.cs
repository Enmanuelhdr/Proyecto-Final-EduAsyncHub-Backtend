using System;
using System.Collections.Generic;

namespace ProyectoFinal.Models
{
    public partial class Carrusel
    {
        public int CarruselId { get; set; }
        public string ImagenUrl { get; set; } = null!;
        public string Titulo { get; set; } = null!;
        public string? Descripcion { get; set; }
    }
}
