using ProyectoFinal.Models;
using System.Runtime.InteropServices;

namespace ProyectoFinal.DTOs
{
    public class TeacherDTO
    {

        public class TeachMatterRequestDto
        {
            public string TeacherUserId { get; set; }
            public int MateriaId { get; set; }
            public int GradoId { get; set; }


        }

        public class AssistancePublishRequestDto
        {
            public string StundentUserId { get; set; }
            public int MateriaId { get; set; }
            public string TeacherUserId { get; set; }
            public bool Asistio { get; set; }
        }

        public class QualificationsStudentRequestDto
        {
            public string StundentUserId { get; set; }
            public int MateriaId { get; set; }
            public string TeacherUserId { get; set; }
            public int Calificacion { get; set; }
            public int Periodo { get; set; }
            public DateTime FechaPublicacion { get; set; }
        }

    }
}
