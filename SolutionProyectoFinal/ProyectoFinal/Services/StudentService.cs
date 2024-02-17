using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Context;
using ProyectoFinal.Interfaces;
using ProyectoFinal.Models;
using static ProyectoFinal.DTOs.StudentDTO;

namespace ProyectoFinal.Services
{
    public class StudentService : IStudentService
    {
        private readonly EduAsyncHubContext _context;

        public StudentService(EduAsyncHubContext dbContext)
        {
            _context = dbContext;
        }

        public async Task EnrollCareerStudent(EnrollCareerStudentRequestDto student)
        {

            var studentSelect = await _context.Estudiantes.FirstOrDefaultAsync(u => u.EstudianteId == student.EstudianteId);

            studentSelect.CarreraId = student.CarreraId;

            await _context.SaveChangesAsync();
        }

        public async Task EnrollSubjectStudent(EnrollSubjectStudentRequestDto student)
        {

            var stundentSubject = new EstudianteMaterium
            {
                EstudianteId = student.EstudianteId,
                MateriaId = student.MateriaId
            };


            _context.EstudianteMateria.Add(stundentSubject);

            await _context.SaveChangesAsync();
        }
    }
}
