using FluentValidation;
using static ProyectoFinal.DTOs.UsuarioDTO;
using ProyectoFinal.Models;


namespace ProyectoFinal.Validations
{
    public class SolicitudAdmisionValidator : AbstractValidator<SolicitudAdmision>
    {
        public SolicitudAdmisionValidator()
        {
            RuleFor(x => x.NombreEstudiante).NotEmpty().MaximumLength(100);
            RuleFor(x => x.FechaNacimiento).NotNull();
            RuleFor(x => x.Genero).NotEmpty().MaximumLength(20);
            RuleFor(x => x.DireccionEstudiante).NotEmpty();
            RuleFor(x => x.Grado).InclusiveBetween(1, 12);
            RuleFor(x => x.EscuelaActual).MaximumLength(100);
            RuleFor(x => x.NombrePadreTutor).NotEmpty().MaximumLength(100);
            RuleFor(x => x.RelacionEstudiante).NotEmpty().MaximumLength(50);
            RuleFor(x => x.DireccionPadreTutor).NotEmpty();
            RuleFor(x => x.NumeroTelefono).NotEmpty().MaximumLength(20);
            RuleFor(x => x.CorreoElectronico).NotEmpty().EmailAddress();
            RuleFor(x => x.FechaHoraSolicitud).NotNull();
        }
    }
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

    public class LoginUserValidator : AbstractValidator<LoginUserRequestDto>
    {
        public LoginUserValidator()
        {
            RuleFor(x => x.CorreoElectronico).NotEmpty().EmailAddress();
            RuleFor(x => x.Contraseña).NotEmpty().MinimumLength(8);
        }
    }

    public class UpdateUserValidator : AbstractValidator<UpdateUserRequestDto>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.UsuarioID).NotEmpty();
            RuleFor(x => x.Nombre).NotEmpty().Length(1, 100);
            RuleFor(x => x.CorreoElectronico).NotEmpty().EmailAddress();
            RuleFor(x => x.Contraseña).NotEmpty().MinimumLength(8);
            RuleFor(x => x.RolID).InclusiveBetween(1, 3);
        }
    }

    public class DeleteUserValidator : AbstractValidator<DeleteUserRequestDto>
    {
        public DeleteUserValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
        }
    }

    public class UpdateProfileValidator : AbstractValidator<UpdateProfileRequestDto>
    {
        public UpdateProfileValidator()
        {
            RuleFor(x => x.UsuarioID).NotEmpty();
            RuleFor(x => x.Nombre).NotEmpty().Length(1, 100);
            RuleFor(x => x.CorreoElectronico).NotEmpty().EmailAddress();
            RuleFor(x => x.Contraseña).NotEmpty().MinimumLength(8);
        }
    }
}
