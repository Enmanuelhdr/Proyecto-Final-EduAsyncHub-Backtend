using System;
using System.Collections.Generic;

namespace ProyectoFinal.Models
{
    public partial class Noticia
    {
        public int Id { get; set; }
        public string? Img { get; set; }
        public string? Title { get; set; }
        public string? Date { get; set; }
        public string? Description { get; set; }
    }
}
