using ProyectoFinal.Models;
using static ProyectoFinal.DTOs.TeacherDTO;

namespace ProyectoFinal.Interfaces
{
    public interface ITeacherService
    {
        Task TeachMatterSubject(TeachMatterRequestDto teachMatter);

        Task<List<object>> AllSubjectsTaught(AllSubjectsTaughtRequestDto teacher);

        Task PublishAssistance(AssistancePublishRequestDto assistance);

        Task QualificationsStudents(QualificationsStudentRequestDto qualificationsStudent);

        Task<List<object>> ObtenerEstudiantesPorProfesor(int profesorId);

    }
}
