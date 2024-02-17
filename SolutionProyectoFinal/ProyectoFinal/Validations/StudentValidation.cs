using FluentValidation;
using static ProyectoFinal.DTOs.StudentDTO;

namespace ProyectoFinal.Validations
{
    public class StudentValidation
    {
        public class EnrollCareerStudentValidator : AbstractValidator<EnrollCareerStudentRequestDto>
        {
            public EnrollCareerStudentValidator()
            {
                RuleFor(x => x.EstudianteId).GreaterThan(0);
                RuleFor(x => x.CarreraId).InclusiveBetween(1, 6);

            }
        }
    }
}
