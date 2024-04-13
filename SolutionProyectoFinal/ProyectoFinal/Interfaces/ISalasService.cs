using ProyectoFinal.Models;

namespace ProyectoFinal.Interfaces
{
    public interface ISalasService
    {

        Task CrearSalaAsync(Sala sala);
        Task<List<Sala>> ObtenerSalasAsync();

    }
}
