using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Context;
using ProyectoFinal.Interfaces;
using ProyectoFinal.Models;
using static ProyectoFinal.DTOs.StudentDTO;
using static ProyectoFinal.DTOs.TeacherDTO;

namespace ProyectoFinal.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly EduAsyncHubContext _context;

        public TeacherService(EduAsyncHubContext dbContext)
        {
            _context = dbContext;
        }

        public async Task TeachMatterSubject(TeachMatterRequestDto teachMatter)
        {

            var teacherSubject = new ProfesorMaterium
            {
                ProfesorId = teachMatter.ProfesorId,
                MateriaId = teachMatter.MateriaId
            };


            _context.ProfesorMateria.Add(teacherSubject);
            await _context.SaveChangesAsync();
        }
    }
}
