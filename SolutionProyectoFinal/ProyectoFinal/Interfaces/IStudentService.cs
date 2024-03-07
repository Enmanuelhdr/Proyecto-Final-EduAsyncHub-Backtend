using ProyectoFinal.Models;
using static ProyectoFinal.DTOs.FiltrosDTO;
using static ProyectoFinal.Services.StudentService;

namespace ProyectoFinal.Interfaces
{
    public interface IStudentService
    {
        Task<List<object>> SubjectsEnrolledByStudent(UserFilterRequestDto student);

        Task<List<object>> ViewQualifications(UserFilterRequestDto viewQualifications);

        Task<List<object>> ViewAssitance(UserFilterRequestDto viewAssitance);
    }
}
