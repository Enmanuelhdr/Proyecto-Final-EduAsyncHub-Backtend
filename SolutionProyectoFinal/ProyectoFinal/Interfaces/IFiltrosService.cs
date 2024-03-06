using ProyectoFinal.Models;
using static ProyectoFinal.DTOs.FiltrosDTO;

namespace ProyectoFinal.Interfaces
{
    public interface IFiltrosService
    {
        Task<Usuario> GetUserForId(UserFilterRequestDto userFilter);

        Task<Estudiante> GetStudentForId(UserFilterRequestDto studentFilter);

        Task<Profesore> GetTeacherForId(UserFilterRequestDto teacherFilter);

        Task<Materia> GetSubjectForId(SubjectFilterRequestDto subjectFilter);

    }
}
