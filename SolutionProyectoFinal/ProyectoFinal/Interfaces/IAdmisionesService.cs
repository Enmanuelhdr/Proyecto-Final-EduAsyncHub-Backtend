using ProyectoFinal.Models;
using static ProyectoFinal.DTOs.UsuarioDTO;

namespace ProyectoFinal.Interfaces
{
    public interface IAdmisionesService
    {
        Task<SolicitudAdmision> GetAdmisionById(int id);

        Task<List<SolicitudAdmision>> GetAllAdmisiones();

        Task CreateAdmision(SolicitudAdmision admision);

        Task UpdateAdmision(int id, SolicitudAdmision admision);

        Task DeleteAdmision(int id);

         Task ApproveAdmision(int id ,string comentario);

         Task RejectAdmision(int id, string comentario);

    }
}
