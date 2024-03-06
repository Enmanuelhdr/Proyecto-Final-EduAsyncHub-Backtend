using FluentValidation;
using static ProyectoFinal.DTOs.StudentDTO;
using static ProyectoFinal.DTOs.UsuarioDTO;

namespace ProyectoFinal.Validations
{
    public class StudentValidation
    {
        public class EnrollSubjectStudentValidator : AbstractValidator<EnrollSubjectStudentRequestDto>
        {
            public EnrollSubjectStudentValidator()
            {
                RuleFor(x => x.EstudianteId).GreaterThan(0);
                RuleFor(x => x.MateriaId).InclusiveBetween(1, 28);

            }
        }

        public class AllSubjectsStudentValidator : AbstractValidator<AllSubjectsStudentRequestDto>
        {
            public AllSubjectsStudentValidator()
            {
                RuleFor(x => x.EstudianteId).GreaterThan(0);
            }
        }

        public class ViewQualificationsValidator : AbstractValidator<ViewQualificationsRequestDto>
        {
            public ViewQualificationsValidator()
            {
                RuleFor(x => x.EstudianteId).GreaterThan(0);
            }
        }

        public class ViewAssitanceValidator : AbstractValidator<ViewAssitanceRequestDto>
        {
            public ViewAssitanceValidator()
            {
                RuleFor(x => x.EstudianteId).GreaterThan(0);
            }
        }


    }
}
