using static ProyectoFinal.DTOs.StudentDTO;

namespace ProyectoFinal.Interfaces
{
    public interface IStudentService
    {
        Task EnrollCareerStudent(EnrollCareerStudentRequestDto student);

        Task EnrollSubjectStudent(EnrollSubjectStudentRequestDto student);

        Task<List<object>> SubjectsEnrolledByStudent(AllSubjectsStudentRequestDto student);
    }
}
