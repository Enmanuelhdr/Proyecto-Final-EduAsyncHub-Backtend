using FluentValidation;
using static ProyectoFinal.DTOs.FiltrosDTO;

namespace ProyectoFinal.Validations
{
    public class FiltrosValidation
    {
        public class UserFilterValidator : AbstractValidator<UserFilterRequestDto>
        {
            public UserFilterValidator()
            {
                RuleFor(x => x.UserId).NotEmpty();
            }
        }

        public class SubjectFilterValidator : AbstractValidator<SubjectFilterRequestDto>
        {
            public SubjectFilterValidator()
            {
                RuleFor(x => x.SubjectId).InclusiveBetween(1,28);
            }
        }

    }
}
