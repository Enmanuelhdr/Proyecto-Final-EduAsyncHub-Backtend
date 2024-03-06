using System;
using System.Collections.Generic;

namespace ProyectoFinal.Models
{
    public partial class Materia
    {
        public Materia()
        {
            Asistencia = new HashSet<Asistencia>();
            Calificaciones = new HashSet<Calificacione>();
            EstudianteMateria = new HashSet<EstudianteMaterium>();
            NotaTotals = new HashSet<NotaTotal>();
            ProfesorMateria = new HashSet<ProfesorMaterium>();
        }

        public int MateriaId { get; set; }
        public string NombreMateria { get; set; } = null!;

        public virtual ICollection<Asistencia> Asistencia { get; set; }
        public virtual ICollection<Calificacione> Calificaciones { get; set; }
        public virtual ICollection<EstudianteMaterium> EstudianteMateria { get; set; }
        public virtual ICollection<NotaTotal> NotaTotals { get; set; }
        public virtual ICollection<ProfesorMaterium> ProfesorMateria { get; set; }
    }
}
