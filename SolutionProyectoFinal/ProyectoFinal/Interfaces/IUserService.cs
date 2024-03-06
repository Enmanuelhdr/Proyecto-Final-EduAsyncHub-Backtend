using static ProyectoFinal.DTOs.UsuarioDTO;

namespace ProyectoFinal.Interfaces
{
    public interface IUserService
    {
        Task RegisterUser(RegisterUserRequestDto usuario , int gradoId = 0);

        Task<(bool, string)> LoginUser(LoginUserRequestDto request);

        Task UpdateProfile(UpdateProfileRequestDto request);


    }
}
