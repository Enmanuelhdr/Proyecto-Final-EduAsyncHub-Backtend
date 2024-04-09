using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Context;
using ProyectoFinal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoFinal.Models;
using static ProyectoFinal.DTOs.UsuarioDTO;
using System.Text;
using System.Security.Cryptography;


namespace ProyectoFinal.Services
{
    public class AdmisionesService : IAdmisionesService
    {
        private readonly EduAsyncHubContext _context;
        private readonly IUserService _userService;

        public AdmisionesService(EduAsyncHubContext dbContext, IUserService userService)
        {
            _context = dbContext;
            _userService = userService;
        }

        public async Task<SolicitudAdmision> GetAdmisionById(int id)
        {
            return await _context.SolicitudAdmisions.FindAsync(id);
        }

        public async Task<List<SolicitudAdmision>> GetAllAdmisiones()
        {
            return await _context.SolicitudAdmisions.ToListAsync();
        }

        public async Task CreateAdmision(SolicitudAdmision admision)
        {
            admision.EstadoSolicitud = "pendiente";
            _context.SolicitudAdmisions.Add(admision);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAdmision(int id, SolicitudAdmision admision)
        {
            var existingAdmision = await _context.SolicitudAdmisions.FindAsync(id);
            if (existingAdmision == null)
            {
                throw new ArgumentException("Solicitud de admisión no encontrada");
            }


            existingAdmision.NombreEstudiante = admision.NombreEstudiante;
            existingAdmision.FechaNacimiento = admision.FechaNacimiento;
            existingAdmision.Genero = admision.Genero;
            existingAdmision.DireccionEstudiante = admision.DireccionEstudiante;
            existingAdmision.Grado = admision.Grado;
            existingAdmision.EscuelaActual = admision.EscuelaActual;
            existingAdmision.NombrePadreTutor = admision.NombrePadreTutor;
            existingAdmision.RelacionEstudiante = admision.RelacionEstudiante;
            existingAdmision.DireccionPadreTutor = admision.DireccionPadreTutor;
            existingAdmision.NumeroTelefono = admision.NumeroTelefono;
            existingAdmision.CorreoElectronico = admision.CorreoElectronico;
            existingAdmision.FechaHoraSolicitud = admision.FechaHoraSolicitud;
            existingAdmision.EstadoSolicitud = admision.EstadoSolicitud;
            existingAdmision.NotasComentarios = admision.NotasComentarios;

            await _context.SaveChangesAsync();
        }


        public async Task DeleteAdmision(int id)
        {
            var admision = await _context.SolicitudAdmisions.FindAsync(id);
            if (admision == null)
            {
                throw new ArgumentException("Solicitud de admisión no encontrada");
            }

            _context.SolicitudAdmisions.Remove(admision);
            await _context.SaveChangesAsync();
        }

        public async Task RejectAdmision(int id, string comentario)
        {
            var admision = await _context.SolicitudAdmisions.FindAsync(id);
            if (admision == null)
            {
                throw new ArgumentException("Solicitud de admisión no encontrada");
            }

            admision.EstadoSolicitud = "Rechazada";
            admision.NotasComentarios = comentario; 
            await _context.SaveChangesAsync();
        }

        public async Task ApproveAdmision(int id, string comentario)
        {
            var admision = await _context.SolicitudAdmisions.FindAsync(id);
            if (admision == null)
            {
                throw new ArgumentException("Solicitud de admisión no encontrada");
            }

            admision.EstadoSolicitud = "Aprobada";
            admision.NotasComentarios = comentario; 
            await _context.SaveChangesAsync();

            await CreateUserFromAdmision(admision);
        }

        private async Task CreateUserFromAdmision(SolicitudAdmision admision)
        {
            var ultimoUsuario = _context.Usuarios.OrderByDescending(x => x.UsuarioId).FirstOrDefault();
            int siguienteNumero = (ultimoUsuario != null) ? int.Parse(ultimoUsuario.UsuarioId.Substring(4)) + 1 : 1;
            string nuevoId = $"EAH-{siguienteNumero:D4}";

            string contraseña = ConvertSha256(nuevoId);

            var usuario = new RegisterUserRequestDto
            {
                Nombre = admision.NombreEstudiante,
                CorreoElectronico = admision.CorreoElectronico,
                Contraseña = contraseña,
                RolID = 1 
            };

            await _userService.RegisterUser(usuario, admision.Grado);
        }


        private bool AdmisionExists(int id)
        {
            return _context.SolicitudAdmisions.Any(e => e.SolicitudId == id);
        }

        private string ConvertSha256(string inputString)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(inputString));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
