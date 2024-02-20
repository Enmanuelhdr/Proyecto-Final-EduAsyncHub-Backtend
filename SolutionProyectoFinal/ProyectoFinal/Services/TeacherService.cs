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

        public async Task<List<object>> AllSubjectsTaught(AllSubjectsTaughtRequestDto teacher)
        {
            var subjectsTaught = await _context.ProfesorMateria
                .Where(pm => pm.ProfesorId == teacher.ProfesorId)
                .Select(pm => new
                {
                    materiaId = pm.Materia.MateriaId,
                    nombreMateria = pm.Materia.NombreMateria
                })
                .ToListAsync();

            return subjectsTaught.Cast<object>().ToList();
        }

        public async Task CreateTask(TaskPublishRequestDto newTask)
        {
            var task = new Asignacione
            {
                MateriaId = newTask.MateriaId,
                ProfesorId = newTask.ProfesorId,
                Titulo = newTask.Titulo,
                Descripcion = newTask.Descripcion,
                FechaVencimiento = newTask.FechaVencimiento
            };

            _context.Asignaciones.Add(task);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTask(TaskUpdatehRequestDto updateTask)
        {

            var taskSelect = await _context.Asignaciones.FirstOrDefaultAsync(u => u.AsignacionId == updateTask.TareaId);

            taskSelect.Titulo = updateTask.Titulo;
            taskSelect.Descripcion = updateTask.Descripcion;
            taskSelect.FechaVencimiento = updateTask.FechaVencimiento;
        
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTask(TaskDeleteRequestDto deleteTask)
        {

            var taskSelect = await _context.Asignaciones.FindAsync(deleteTask.TareaId);

            _context.Asignaciones.Remove(taskSelect);
            await _context.SaveChangesAsync();

        }

        public async Task QualificationsAssignments(QualificationsAssignmentsRequestDTO qualificationAssignments)
        {

            var assignmentsSelect = await _context.RespuestasEstudiantes.FirstOrDefaultAsync(u => u.RespuestaId == qualificationAssignments.RespuestaId);


            assignmentsSelect.Calificacion = qualificationAssignments.Calificacion;
            assignmentsSelect.ComentariosProfesor = qualificationAssignments.Comentarios;


            await _context.SaveChangesAsync();
        }
    }
}
