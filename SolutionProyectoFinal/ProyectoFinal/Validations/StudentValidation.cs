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

        public class SubmitAssignmentValidator : AbstractValidator<SubmitAssignmentRequestDto>
        {
            public SubmitAssignmentValidator()
            {
                RuleFor(x => x.EstudianteId).GreaterThan(0);
                RuleFor(x => x.AsignacionId).GreaterThan(0);
            }
        }

        public class EditAssignmentValidator : AbstractValidator<EditAssignmentRequestDto>
        {
            public EditAssignmentValidator()
            {
                RuleFor(x => x.EstudianteId).GreaterThan(0);
                RuleFor(x => x.AsignacionId).GreaterThan(0);
                RuleFor(x => x.Respuesta).NotEmpty();
            }
        }

        public class DeleteAssignmentValidator : AbstractValidator<DeleteAssignmentRequestDto>
        {
            public DeleteAssignmentValidator()
            {
                RuleFor(x => x.EstudianteId).GreaterThan(0);
                RuleFor(x => x.AsignacionId).GreaterThan(0);
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
