using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Interfaces;
using ProyectoFinal.Models;
using System.Data;
using System;
using static ProyectoFinal.DTOs.StudentDTO;
using static ProyectoFinal.DTOs.TeacherDTO;
using Microsoft.Extensions.Hosting.Internal;
using ProyectoFinal.Context;

namespace ProyectoFinal.Services
{
    public class StudentService : IStudentService
    {
        private readonly EduAsyncHubContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public StudentService(EduAsyncHubContext dbContext, IWebHostEnvironment hostingEnvironment)
        {
            _context = dbContext;
            _hostingEnvironment = hostingEnvironment;
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

        public async Task<List<object>> ViewQualifications(ViewQualificationsRequestDto viewQualifications)
        {
            var qualifications = await _context.Calificaciones
                .Where(c => c.EstudianteId == viewQualifications.EstudianteId)
                .GroupBy(c => c.MateriaId)
                .Select(group => new
                {
                    Materia = group.First().Materia.NombreMateria,
                    Notas = group.Select(c => new
                    {
                        Periodo = c.Periodo,
                        Calificacion = c.Calificacion
                    }),
                    NotaTotal = _context.NotaTotals
                        .Where(nt => nt.EstudianteId == viewQualifications.EstudianteId && nt.MateriaId == group.Key)
                        .Select(nt => nt.NotaTotal1)
                        .FirstOrDefault()
                })
                .ToListAsync();

            return qualifications.Cast<object>().ToList();
        }





        public async Task<List<object>> ViewAssitance(ViewAssitanceRequestDto viewAssitance)
        {
            var assistanceDetails = await _context.Asistencias
                .Where(a => a.EstudianteId == viewAssitance.EstudianteId)
                .Select(a => new
                {
                    Materia = a.Materia.NombreMateria,
                    Fecha = a.FechaAsistencia,
                    AsistenciaStatus = a.Asistio == true ? "Asistió" : "No Asistió"
                })
                .ToListAsync();

            var totalAssistances = await _context.Asistencias
                .CountAsync(a => a.EstudianteId == viewAssitance.EstudianteId && a.Asistio == true);

            var totalInassitances = await _context.Asistencias
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
