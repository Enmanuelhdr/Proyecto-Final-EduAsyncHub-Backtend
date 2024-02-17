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
    }
}
