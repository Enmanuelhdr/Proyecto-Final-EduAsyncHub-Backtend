using ProyectoFinal.Models;
using System.Runtime.InteropServices;

namespace ProyectoFinal.DTOs
{
    public class TeacherDTO
    {
        public class AllSubjectsTaughtRequestDto
        {
            public int ProfesorId { get; set; }

        }

        public class TeachMatterRequestDto
        {
            public int ProfesorId { get; set; }
            public int MateriaId { get; set; }
            public int GradoId { get; set; }


        }

        public class AssistancePublishRequestDto
        {
            public int EstudianteId { get; set; }
            public int MateriaId { get; set; }
            public int ProfesorId { get; set; }
            public bool Asistio { get; set; }
        }

        public class QualificationsStudentRequestDto
        {
            public int EstudianteId { get; set; }
            public int MateriaId { get; set; }
            public int ProfesorId { get; set; }
            public int Calificacion { get; set; }
            public int Periodo { get; set; }
            public DateTime FechaPublicacion { get; set; }
        }

    }
}
