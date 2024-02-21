using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Context;
using ProyectoFinal.Interfaces;
using ProyectoFinal.Models;
using static ProyectoFinal.DTOs.FiltrosDTO;

namespace ProyectoFinal.Services
{
    public class FiltrosService : IFiltrosService
    {
        private readonly EduAsyncHubContext _context;

        public FiltrosService(EduAsyncHubContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<Usuario> GetUserForId(UserFilterRequestDto userFilter)
        {
            var user = await _context.Usuarios.FirstOrDefaultAsync(u => u.UsuarioId == userFilter.UserId);

            return user;
        }

    }
}
