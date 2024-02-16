using ProyectoFinal.Context;
using ProyectoFinal.Interfaces;
using ProyectoFinal.Models;
using System.Security.Cryptography;
using System.Text;
using static ProyectoFinal.DTOs.UsuarioDTO;

namespace ProyectoFinal.Services
{
    public class UserService : IUserService
    {
        private readonly EduAsyncHubContext _context;

        public UserService(EduAsyncHubContext dbContext)
        {
            _context = dbContext;
        }

        public async Task RegisterUser(RegisterUserRequestDto usuario)
        {
            usuario.Contraseña = ConvertSha256(usuario.Contraseña);

            // Mapea el DTO a la entidad Usuario
            var user = new Usuario
            {
                Nombre = usuario.Nombre,
                CorreoElectronico = usuario.CorreoElectronico,
                Contraseña = usuario.Contraseña,
                RolId = usuario.RolID,
            };

            // Agrega el usuario a la base de datos
            _context.Usuarios.Add(user);
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
