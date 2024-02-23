using System;
using System.Collections.Generic;

namespace ProyectoFinal.Models
{
    public partial class Profesore
    {
        public Profesore()
        {
            Asignaciones = new HashSet<Asignacione>();
            Asistencia = new HashSet<Asistencium>();
            Calificaciones = new HashSet<Calificacione>();
            Materia = new HashSet<Materia>();
        }

        public int ProfesorId { get; set; }
        public int? UsuarioId { get; set; }

        public virtual Usuario? Usuario { get; set; }
        public virtual ICollection<Asignacione> Asignaciones { get; set; }
        public virtual ICollection<Asistencium> Asistencia { get; set; }
        public virtual ICollection<Calificacione> Calificaciones { get; set; }

        public virtual ICollection<Materia> Materia { get; set; }
    }
}
