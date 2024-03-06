using ProyectoFinal.Models;
using static ProyectoFinal.DTOs.StudentDTO;
using static ProyectoFinal.Services.StudentService;

namespace ProyectoFinal.Interfaces
{
    public interface IStudentService
    {
        Task EnrollSubjectStudent(EnrollSubjectStudentRequestDto student);

        Task<List<object>> SubjectsEnrolledByStudent(AllSubjectsStudentRequestDto student);

        Task<List<object>> ViewQualifications(ViewQualificationsRequestDto viewQualifications);

        Task<List<object>> ViewAssitance(ViewAssitanceRequestDto viewAssitance);
    }
}
