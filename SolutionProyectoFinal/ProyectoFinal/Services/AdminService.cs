using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProyectoFinal.Interfaces;
using ProyectoFinal.Models;
using static ProyectoFinal.DTOs.UsuarioDTO;
using System.Text;
using System.Security.Cryptography;
using ProyectoFinal.Context;


namespace ProyectoFinal.Services
{
    public class AdminService : IAdminService
    {
        private readonly EduAsyncHubContext _context;

        public AdminService(EduAsyncHubContext dbContext)
        {
            _context = dbContext;
        }



        public async Task EditAnyUserAdmin(UpdateUserRequestDto usuario)
        {
            var user = await _context.Usuarios.FindAsync(usuario.UsuarioID);

            var claveEncriptada = ConvertSha256(usuario.Contraseña);

            user.Nombre = usuario.Nombre;
            user.CorreoElectronico = usuario.CorreoElectronico;
            user.Contraseña = claveEncriptada;
            user.RolId = usuario.RolID;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAnyUserAdmin(DeleteUserRequestDto usuario)
        {
            var user = await _context.Usuarios.FindAsync(usuario.UserId);


            var student = await _context.Estudiantes.FirstOrDefaultAsync(e => e.UsuarioId == usuario.UserId);

            if (student != null)
            {
                var estudianteId = student.EstudianteId;

                var calificacionesRecords = await _context.Calificaciones
                    .Where(c => c.EstudianteId == estudianteId)
                    .ToListAsync();

                _context.Calificaciones.RemoveRange(calificacionesRecords);

                await _context.SaveChangesAsync();

                var estudianteMateriaRecords = await _context.EstudianteMateria
                    .Where(em => em.EstudianteId == estudianteId)
                    .ToListAsync();

                _context.EstudianteMateria.RemoveRange(estudianteMateriaRecords);

                _context.Estudiantes.Remove(student);

                await _context.SaveChangesAsync();
            }

            var teacher = await _context.Profesores.FirstOrDefaultAsync(p => p.UsuarioId == usuario.UserId);

            if (teacher != null)
            {
                var profesorId = teacher.ProfesorId;

                var profesorMateriaRecords = await _context.ProfesorMateria
                    .Where(em => em.ProfesorId == profesorId)
                    .ToListAsync();

                _context.ProfesorMateria.RemoveRange(profesorMateriaRecords);
                await _context.SaveChangesAsync();

                _context.Profesores.Remove(teacher);
            }


            _context.Usuarios.Remove(user);
            await _context.SaveChangesAsync();
        }


        public async Task<List<Usuario>> GetAllUsuarios()
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            return usuarios;
        }

        public async Task<List<Usuario>> GetEstudiantes()
        {
            var estudiantes = await _context.Usuarios
                .Where(u => u.Rol.NombreRol == "Estudiante")
                .ToListAsync();

            return estudiantes;
        }

        public async Task<List<Usuario>> GetProfesores()
        {
            var estudiantes = await _context.Usuarios
                .Where(u => u.Rol.NombreRol == "Profesor")
                .ToListAsync();

            return estudiantes;
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
