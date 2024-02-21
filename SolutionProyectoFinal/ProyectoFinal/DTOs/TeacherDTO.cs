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

        }

        public class TaskPublishRequestDto
        {
            public int MateriaId { get; set; }
            public int ProfesorId { get; set; }
            public string Titulo { get; set; }
            public string Descripcion { get; set; }

            public DateTime? FechaVencimiento { get; set; }
        }

        public class TaskUpdatehRequestDto
        {
            public int TareaId { get; set; }
            public int MateriaId { get; set; }
            public int ProfesorId { get; set; }
            public string Titulo { get; set; }
            public string Descripcion { get; set; }

            public DateTime? FechaVencimiento { get; set; }
        }

        public class TaskDeleteRequestDto
        {
            public int TareaId { get; set; }
            public int MateriaId { get; set; }
            public int ProfesorId { get; set; }

        }

        public class QualificationsAssignmentsRequestDTO
        {
            public int RespuestaId { get; set; }
            public int EstudianteId { get; set; }
            public int Calificacion { get; set; }
            public string Comentarios { get; set; }


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
            public DateTime FechaPublicacion { get; set; }
        }

    }
}
