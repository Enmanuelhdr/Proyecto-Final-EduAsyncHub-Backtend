using FluentValidation;
using static ProyectoFinal.DTOs.FiltrosDTO;
using static ProyectoFinal.DTOs.StudentDTO;

namespace ProyectoFinal.Validations
{
    public class FiltrosValidation
    {
        public class UserFilterValidator : AbstractValidator<UserFilterRequestDto>
        {
            public UserFilterValidator()
            {
                RuleFor(x => x.UserId).GreaterThan(0);
            }
        }
    }
}
