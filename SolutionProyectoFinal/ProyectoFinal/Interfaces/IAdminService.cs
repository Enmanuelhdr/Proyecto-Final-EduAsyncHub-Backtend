using static ProyectoFinal.DTOs.UsuarioDTO;

namespace ProyectoFinal.Interfaces
{
    public interface IAdminService
    {
        Task EditAnyUserAdmin(int id, UpdateUserRequestDto usuario);

        Task DeleteAnyUserAdmin(DeleteUserRequestDto usuario);
    }
}
