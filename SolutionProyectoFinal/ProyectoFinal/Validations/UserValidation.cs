using FluentValidation;
using static ProyectoFinal.DTOs.UsuarioDTO;

namespace ProyectoFinal.Validations
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserRequestDto>
    {
        public RegisterUserValidator()
        {
            RuleFor(x => x.Nombre).NotEmpty().Length(1, 100);
            RuleFor(x => x.CorreoElectronico).NotEmpty().EmailAddress();
            RuleFor(x => x.Contraseña).NotEmpty().MinimumLength(8);
            RuleFor(x => x.RolID).InclusiveBetween(1, 3);
        }
    }
   
}
