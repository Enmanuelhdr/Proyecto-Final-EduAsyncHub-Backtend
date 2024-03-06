using System;
using System.Collections.Generic;

namespace ProyectoFinal.Models
{
    public partial class Profesore
    {
        public Profesore()
        {
            Asistencia = new HashSet<Asistencia>();
            Calificaciones = new HashSet<Calificacione>();
            ProfesorMateria = new HashSet<ProfesorMaterium>();
        }

        public int ProfesorId { get; set; }
        public string? UsuarioId { get; set; }

        public virtual Usuario? Usuario { get; set; }
        public virtual ICollection<Asistencia> Asistencia { get; set; }
        public virtual ICollection<Calificacione> Calificaciones { get; set; }
        public virtual ICollection<ProfesorMaterium> ProfesorMateria { get; set; }
    }
}
