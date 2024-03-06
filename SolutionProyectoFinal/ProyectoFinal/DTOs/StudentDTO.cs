namespace ProyectoFinal.DTOs
{
    public class StudentDTO
    {
        public class EnrollSubjectStudentRequestDto
        {
            public int EstudianteId { get; set; }
            public int MateriaId { get; set; }

        }

         public class AllSubjectsStudentRequestDto
         {
           public int EstudianteId { get; set; }

         }

        public class ViewQualificationsRequestDto
        {
            public int EstudianteId { get; set; }

        }

        public class ViewAssitanceRequestDto
        {
            public int EstudianteId { get; set; }

        }

    }
}
