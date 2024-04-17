using ProyectoFinal.DTOs;
using ProyectoFinal.Models;

namespace ProyectoFinal.Interfaces
{
    public interface ISalasService
    {

        Task CrearSalaAsync(SalasDTOcs sala);
        Task<List<Sala>> ObtenerSalasAsync();

    }
}
