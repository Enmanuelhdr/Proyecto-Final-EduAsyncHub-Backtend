using static ProyectoFinal.DTOs.TeacherDTO;

namespace ProyectoFinal.Interfaces
{
    public interface ITeacherService
    {
        Task TeachMatterSubject(TeachMatterRequestDto teachMatter);
    }
}
