using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProyectoFinal.Interfaces;
using ProyectoFinal.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using static ProyectoFinal.DTOs.UsuarioDTO;
using static ProyectoFinal.DTOs.StudentDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Context;

namespace ProyectoFinal.Services
{
    public class UserService : IUserService
    {
        private readonly EduAsyncHubContext _context;
        private readonly string Key;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public UserService(EduAsyncHubContext dbContext, IWebHostEnvironment hostingEnvironment, IConfiguration config)
        {
            _context = dbContext;
            _hostingEnvironment = hostingEnvironment;
            Key = config.GetSection("settings:Key").Value;

        }

        public async Task RegisterUser(RegisterUserRequestDto usuario, int gradoId = 0)
        {
            usuario.Contraseña = ConvertSha256(usuario.Contraseña);

            // Obtener el último usuario
            var ultimoUsuario = await _context.Usuarios
                .OrderByDescending(x => x.UsuarioId)
                .FirstOrDefaultAsync();

            int siguienteNumero = (ultimoUsuario != null) ? int.Parse(ultimoUsuario.UsuarioId.Substring(4)) + 1 : 1;

            string nuevoId = $"EAH-{siguienteNumero:D4}";

            var user = new Usuario
            {
                UsuarioId = nuevoId,
                Nombre = usuario.Nombre,
                CorreoElectronico = usuario.CorreoElectronico,
                Contraseña = usuario.Contraseña,
                RolId = usuario.RolID,
            };

            _context.Usuarios.Add(user);
            await _context.SaveChangesAsync();

            if (gradoId > 0 && gradoId <= 12 && usuario.RolID == 1)
            {
                var student = new Estudiante
                {
                    UsuarioId = nuevoId,
                    GradoId = gradoId
                };

                _context.Estudiantes.Add(student);
                await _context.SaveChangesAsync();

                var materias = await _context.Materias.ToListAsync();

                foreach (var materia in materias)
                {
                    var estudianteMateria = new EstudianteMaterium
                    {
                        EstudianteId = student.EstudianteId,
                        MateriaId = materia.MateriaId,
                        GradoId = gradoId
                    };

                    _context.EstudianteMateria.Add(estudianteMateria);
                }

                await _context.SaveChangesAsync();
            }
            else if (usuario.RolID == 2)
            {
                var teacher = new Profesore
                {
                    UsuarioId = nuevoId,
                };

                _context.Profesores.Add(teacher);
                await _context.SaveChangesAsync();
            }
        }



        public async Task<(bool, string)> LoginUser(LoginUserRequestDto request)
        {
            var claveEncriptada = ConvertSha256(request.Contraseña);

            var usuario = await _context.Usuarios
                .Include(u => u.Rol)
                .Where(u => u.CorreoElectronico == request.CorreoElectronico && u.Contraseña == claveEncriptada)
                .FirstOrDefaultAsync(); 

            if (usuario != null)
            {
                var keyBytes = Encoding.UTF8.GetBytes(Key);
                var claims = new ClaimsIdentity();

                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, usuario.UsuarioId.ToString()));

                claims.AddClaim(new Claim(ClaimTypes.Name, usuario.CorreoElectronico));

                var rolNombre = await _context.Roles.Where(r => r.RolId == usuario.RolId).Select(r => r.NombreRol).FirstOrDefaultAsync();
                claims.AddClaim(new Claim(ClaimTypes.Role, rolNombre));

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

                string tokenCreado = tokenHandler.WriteToken(tokenConfig);

                return (true, tokenCreado);
            }
            else 
            {
                return (false, "Login inválido");
            }
        }

        public async Task UpdateProfile(UpdateProfileRequestDto updateUser)
        {
            var userSelect = await _context.Usuarios.FirstOrDefaultAsync(u => u.UsuarioId == updateUser.UsuarioID);

            userSelect.Nombre = updateUser.Nombre;
            userSelect.CorreoElectronico = updateUser.CorreoElectronico;
            userSelect.Contraseña = ConvertSha256(updateUser.Contraseña);
           
            _context.Usuarios.Update(userSelect);
            await _context.SaveChangesAsync();
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
