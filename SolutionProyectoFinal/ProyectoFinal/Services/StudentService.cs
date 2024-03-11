using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Interfaces;
using ProyectoFinal.Models;
using System.Data;
using System;
using static ProyectoFinal.DTOs.TeacherDTO;
using static ProyectoFinal.DTOs.FiltrosDTO;
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

        public async Task<List<object>> SubjectsEnrolledByStudent(UserFilterRequestDto student)
        {
            var subjectsEnrolled = await _context.EstudianteMateria
                .Where(em => em.Estudiante.UsuarioId == student.UserId)
                .Select(em => new
                {
                    materiaId = em.Materia.MateriaId,
                    nombreMateria = em.Materia.NombreMateria
                })
                .ToListAsync();

            return subjectsEnrolled.Cast<object>().ToList();
        }

        public async Task<List<object>> ViewQualifications(UserFilterRequestDto viewQualifications)
        {
            var qualifications = await _context.Calificaciones
                .Where(c => c.Estudiante.UsuarioId == viewQualifications.UserId)
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
                        .Where(nt => nt.Estudiante.UsuarioId == viewQualifications.UserId && nt.MateriaId == group.Key)
                        .Select(nt => nt.NotaTotal1)
                        .FirstOrDefault()
                })
                .ToListAsync();

            return qualifications.Cast<object>().ToList();
        }





        public async Task<List<object>> ViewAssitance(UserFilterRequestDto viewAssitance)
        {
            var assistanceDetails = await _context.Asistencias
                .Where(a => a.Estudiante.UsuarioId == viewAssitance.UserId)
                .Select(a => new
                {
                    Materia = a.Materia.NombreMateria,
                    Fecha = a.FechaAsistencia,
                    AsistenciaStatus = a.Asistio == true ? "Asistió" : "No Asistió"
                })
                .ToListAsync();

            var totalAssistances = await _context.Asistencias
                .CountAsync(a => a.Estudiante.UsuarioId == viewAssitance.UserId && a.Asistio == true);

            var totalInassitances = await _context.Asistencias
                .CountAsync(a => a.Estudiante.UsuarioId == viewAssitance.UserId && a.Asistio == false);

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
