using static ProyectoFinal.DTOs.StudentDTO;

namespace ProyectoFinal.Interfaces
{
    public interface IStudentService
    {
        Task EnrollCareerStudent(EnrollCareerStudentRequestDto request);
    }
}
