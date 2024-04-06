using System;
using System.Collections.Generic;

namespace ProyectoFinal.Models
{
    public partial class CalendarioEspecifico
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Date { get; set; }
        public string? Hora { get; set; }
    }
}
