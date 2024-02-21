using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Context;
using ProyectoFinal.Interfaces;
using ProyectoFinal.Models;
using static ProyectoFinal.DTOs.StudentDTO;
using static ProyectoFinal.DTOs.TeacherDTO;

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

        public async Task<List<object>> SubjectsEnrolledByStudent(AllSubjectsStudentRequestDto student)
        {
            var subjectsEnrolled = await _context.EstudianteMateria
                .Where(em => em.EstudianteId == student.EstudianteId)
                .Select(em => new
                {
                    materiaId = em.Materia.MateriaId,
                    nombreMateria = em.Materia.NombreMateria
                })
                .ToListAsync();

            return subjectsEnrolled.Cast<object>().ToList();
        }

        public async Task<List<object>> GetAllAssignmentsForStudent(AllSubjectsStudentRequestDto student)
        {
            var assignments = await _context.EstudianteMateria
                .Where(em => em.EstudianteId == student.EstudianteId &&
                             em.Materia.Asignaciones.Any()) 
                .Select(em => new
                {
                    MateriaNombre = em.Materia.NombreMateria,
                    Asignaciones = em.Materia.Asignaciones
                        .Select(a => new
                        {
                            Titulo = a.Titulo,
                            Descripcion = a.Descripcion,
                            FechaPublicacion = a.FechaPublicacion,
                            FechaVencimiento = a.FechaVencimiento
                        })
                        .ToList()
                })
                .ToListAsync();

            return assignments.Cast<object>().ToList();
        }

        public async Task SubmitAssignment(SubmitAssignmentRequestDto submitAssignment)
        {
            var assignment = new RespuestasEstudiante
            {
                EstudianteId = submitAssignment.EstudianteId,
                AsignacionId = submitAssignment.AsignacionId,
                Respuesta = submitAssignment.Respuesta
            };

            _context.RespuestasEstudiantes.Add(assignment);
            await _context.SaveChangesAsync();
        }

        public async Task EditAssignment(EditAssignmentRequestDto editAssignment)
        {

            var assignmentSelect = await _context.RespuestasEstudiantes.FirstOrDefaultAsync(u => u.AsignacionId == editAssignment.AsignacionId && u.EstudianteId == editAssignment.EstudianteId);

            assignmentSelect.Respuesta = editAssignment.Respuesta;

            await _context.SaveChangesAsync();


        }

        public async Task DeleteAssignment(DeleteAssignmentRequestDto deleteAssignment)
        {

            var assignmentSelect = await _context.RespuestasEstudiantes.FirstOrDefaultAsync(u => u.AsignacionId == deleteAssignment.AsignacionId && u.EstudianteId == deleteAssignment.EstudianteId);

            _context.RespuestasEstudiantes.Remove(assignmentSelect);
            await _context.SaveChangesAsync();

        }

        public async Task<List<object>> ViewQualifications(ViewQualificationsRequestDto viewQualifications)
        { 
            var qualifications = await _context.Calificaciones
                .Where(c => c.EstudianteId == viewQualifications.EstudianteId)
                .Select(c => new
                {
                    Materia = c.Materia.NombreMateria,
                    Calificacion = c.Calificacion,
                })
                .ToListAsync();
                
            return qualifications.Cast<object>().ToList();
        }

        public async Task<List<object>> ViewAssitance(ViewAssitanceRequestDto viewAssitance)
        {
            var assistanceDetails = await _context.Asistencia
                .Where(a => a.EstudianteId == viewAssitance.EstudianteId)
                .Select(a => new
                {
                    Materia = a.Materia.NombreMateria,
                    Fecha = a.FechaAsistencia,
                    AsistenciaStatus = a.Asistio == true ? "Asistió" : "No Asistió"
                })
                .ToListAsync();

            var totalAssistances = await _context.Asistencia
                .CountAsync(a => a.EstudianteId == viewAssitance.EstudianteId && a.Asistio == true);

            var totalInassitances = await _context.Asistencia
                .CountAsync(a => a.EstudianteId == viewAssitance.EstudianteId && a.Asistio == false);

            var result = new
            {
                AssistanceDetails = assistanceDetails,
                TotalAssistances = totalAssistances,
                TotalInassitances = totalInassitances
            };

            return new List<object> { result };
        }




    }
}
