using ProyectoFinal.Models;
using static ProyectoFinal.DTOs.FiltrosDTO;

namespace ProyectoFinal.Interfaces
{
    public interface IFiltrosService
    {
        Task<Usuario> GetUserForId(UserFilterRequestDto userFilter);
    }
}
