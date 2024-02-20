using ProyectoFinal.Models;
using static ProyectoFinal.DTOs.UsuarioDTO;

namespace ProyectoFinal.Interfaces
{
    public interface IAdminService
    {
        Task EditAnyUserAdmin(UpdateUserRequestDto usuario);

        Task DeleteAnyUserAdmin(DeleteUserRequestDto usuario);

        Task<List<Usuario>> GetAllUsuarios();

        Task<List<Usuario>> GetEstudiantes();

        Task<List<Usuario>> GetProfesores();

        Task AsignPermissions(AssignPermissionsUserRequestDto permissionsRequest);
    }
}
