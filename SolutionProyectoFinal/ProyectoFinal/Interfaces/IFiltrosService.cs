using ProyectoFinal.Models;
using static ProyectoFinal.DTOs.FiltrosDTO;

namespace ProyectoFinal.Interfaces
{
    public interface IFiltrosService
    {
        Task<Usuario> GetUserForId(UserFilterRequestDto userFilter);

        Task<Estudiante> GetStudentForId(StudentFilterRequestDto studentFilter);

        Task<Profesore> GetTeacherForId(TeacherFilterRequestDto teacherFilter);

        Task<Carrera> GetCareerForId(CareerFilterRequestDto careerFilter);

        Task<Materia> GetSubjectForId(SubjectFilterRequestDto subjectFilter);
    }
}
