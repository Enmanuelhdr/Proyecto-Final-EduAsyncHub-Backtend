using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Context;
using ProyectoFinal.Interfaces;
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

        public async Task EnrollCareerStudent(EnrollCareerStudentRequestDto request)
        {

            var student = await _context.Estudiantes.FirstOrDefaultAsync(u => u.EstudianteId == request.EstudianteId);

            student.CarreraId = request.CarreraId;

            await _context.SaveChangesAsync();
        }
    }
}
