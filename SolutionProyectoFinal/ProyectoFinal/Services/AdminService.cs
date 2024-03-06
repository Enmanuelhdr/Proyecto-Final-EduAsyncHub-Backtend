using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProyectoFinal.Context;
using ProyectoFinal.Interfaces;
using ProyectoFinal.Models;
using static ProyectoFinal.DTOs.UsuarioDTO;
using static ProyectoFinal.DTOs.StudentDTO;


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

            user.Nombre = usuario.Nombre;
            user.CorreoElectronico = usuario.CorreoElectronico;
            user.Contraseña = usuario.Contraseña;
            user.FotoPerfil = usuario.pfp;
            user.DescripcionBreve = usuario.DescripcionBreve;
            user.Intereses = usuario.Intereses;
            user.Habilidades = usuario.Habilidades;
            user.RolId = usuario.RolID;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAnyUserAdmin(DeleteUserRequestDto usuario)
        {
            var user = await _context.Usuarios.FindAsync(usuario.UserId);

            var student = await _context.Estudiantes.FirstOrDefaultAsync(e => e.UsuarioId == usuario.UserId);

            if (student != null)
            {
                _context.Estudiantes.Remove(student);
            }

            var teacher = await _context.Profesores.FirstOrDefaultAsync(p => p.UsuarioId == usuario.UserId);

            if (teacher != null)
            {
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

    }
}
