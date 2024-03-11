using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Context;
using ProyectoFinal.Interfaces;
using ProyectoFinal.Models;
using static ProyectoFinal.DTOs.FiltrosDTO;

namespace ProyectoFinal.Services
{
    public class FiltrosService : IFiltrosService
    {
        private readonly EduAsyncHubContext _context;

        public FiltrosService(EduAsyncHubContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<Usuario> GetUserForId(UserFilterRequestDto userFilter)
        {
            var user = await _context.Usuarios.FirstOrDefaultAsync(u => u.UsuarioId == userFilter.UserId);

            return user;
        }

        public async Task<Estudiante> GetStudentForId(UserFilterRequestDto studentFilter)
        {
            var student = await _context.Estudiantes.FirstOrDefaultAsync(u => u.UsuarioId == studentFilter.UserId);

            return student;
        }

        public async Task<Profesore> GetTeacherForId(UserFilterRequestDto teacherFilter)
        {
            var teacher = await _context.Profesores.FirstOrDefaultAsync(u => u.UsuarioId == teacherFilter.UserId);

            return teacher;
        }

        public async Task<Materia> GetSubjectForId(SubjectFilterRequestDto subjectFilter)
        {
            var subject = await _context.Materias.FirstOrDefaultAsync(u => u.MateriaId == subjectFilter.SubjectId);

            return subject;
        }

    }
}
