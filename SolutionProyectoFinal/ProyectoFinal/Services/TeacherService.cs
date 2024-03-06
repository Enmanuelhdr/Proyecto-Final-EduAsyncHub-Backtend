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
                MateriaId = teachMatter.MateriaId,
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

        public async Task<List<object>> ObtenerEstudiantesPorProfesor(int profesorId)
        {
            var materiasImpartidas = await _context.ProfesorMateria
                .Where(pm => pm.ProfesorId == profesorId)
                .Select(pm => pm.Materia)
                .ToListAsync();

            var estudiantesInscritos = await _context.EstudianteMateria
                .Where(em => materiasImpartidas.Contains(em.Materia))
                .Select(em => new
                {
                    EstudianteId = em.EstudianteId,
                    NombreEstudiante = _context.Usuarios
                        .Where(u => u.UsuarioId == em.Estudiante.UsuarioId)
                        .Select(u => u.Nombre)
                        .FirstOrDefault(),
                    MateriaId = em.Materia.MateriaId,
                    GradoId = em.GradoId,
                    Materia = em.Materia.NombreMateria,
                    Grado = _context.GradosEscolares
                        .Where(g => g.GradoId == em.GradoId)
                        .Select(g => g.NombreGrado)
                        .FirstOrDefault()
                })
                .ToListAsync();

            return estudiantesInscritos.Cast<object>().ToList();
        }



        public async Task PublishAssistance(AssistancePublishRequestDto assistance)
        {
            var assistancePublish = new Asistencia
            {
                EstudianteId = assistance.EstudianteId,
                MateriaId = assistance.MateriaId,
                ProfesorId = assistance.ProfesorId,
                FechaAsistencia = DateTime.Now,
                Asistio = assistance.Asistio
            };

            _context.Asistencias.Add(assistancePublish);
            await _context.SaveChangesAsync();
        }

        public async Task QualificationsStudents(QualificationsStudentRequestDto qualificationsStudent)
        {
            var qualificationPublish = new Calificacione
            {
                EstudianteId = qualificationsStudent.EstudianteId,
                MateriaId = qualificationsStudent.MateriaId,
                ProfesorId = qualificationsStudent.ProfesorId,
                Calificacion = qualificationsStudent.Calificacion,
                Periodo = qualificationsStudent.Periodo,
                FechaPublicacion = DateTime.Now
            };

            _context.Calificaciones.Add(qualificationPublish);
            await _context.SaveChangesAsync();

            var calificacionesEstudiante = await _context.Calificaciones
                .Where(c => c.EstudianteId == qualificationsStudent.EstudianteId && c.MateriaId == qualificationsStudent.MateriaId)
                .GroupBy(c => c.Periodo)
                .Select(g => g.Average(c => c.Calificacion))
                .ToListAsync();

            if (calificacionesEstudiante.Count >= 4)
            {
                double notaTotal = (double)(calificacionesEstudiante.Sum() / calificacionesEstudiante.Count);

                var notaTotalEntity = await _context.NotaTotals
                    .Where(nt => nt.EstudianteId == qualificationsStudent.EstudianteId && nt.MateriaId == qualificationsStudent.MateriaId)
                    .FirstOrDefaultAsync();

                if (notaTotalEntity == null)
                {
                    _context.NotaTotals.Add(new NotaTotal
                    {
                        EstudianteId = qualificationsStudent.EstudianteId,
                        MateriaId = qualificationsStudent.MateriaId,
                        NotaTotal1 = notaTotal
                    });
                }
                else
                {
                    notaTotalEntity.NotaTotal1 = notaTotal;
                }

                await _context.SaveChangesAsync();
            }
        }


    }
}
