using ProyectoFinal.Models;
using static ProyectoFinal.DTOs.FiltrosDTO;
using static ProyectoFinal.DTOs.TeacherDTO;

namespace ProyectoFinal.Interfaces
{
    public interface ITeacherService
    {
        Task TeachMatterSubject(TeachMatterRequestDto teachMatter);

        Task<List<object>> AllSubjectsTaught(UserFilterRequestDto teacher);

        Task PublishAssistance(AssistancePublishRequestDto assistance);

        Task QualificationsStudents(QualificationsStudentRequestDto qualificationsStudent);

        Task<List<object>> ObtenerEstudiantesPorProfesor(string profesorId);

        Task<List<object>> ObtenerEstudiantesPorMateriaYGrado(int MateriaId, int GradoId);

    }
}
