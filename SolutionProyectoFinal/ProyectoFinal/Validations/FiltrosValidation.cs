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

        public class StudentFilterValidator : AbstractValidator<StudentFilterRequestDto>
        {
            public StudentFilterValidator()
            {
                RuleFor(x => x.StudentId).GreaterThan(0);
            }
        }

        public class TeacherFilterValidator : AbstractValidator<TeacherFilterRequestDto>
        {
            public TeacherFilterValidator()
            {
                RuleFor(x => x.TeacherId).GreaterThan(0);
            }
        }

        public class CareerFilterValidator : AbstractValidator<CareerFilterRequestDto>
        {
            public CareerFilterValidator()
            {
                RuleFor(x => x.CareerId).InclusiveBetween(1,28);
            }
        }

        public class SubjectFilterValidator : AbstractValidator<SubjectFilterRequestDto>
        {
            public SubjectFilterValidator()
            {
                RuleFor(x => x.SubjectId).InclusiveBetween(1,28);
            }
        }

        public class AssignmentsFilterValidator : AbstractValidator<AssignmentsFilterRequestDto>
        {
            public AssignmentsFilterValidator()
            {
                RuleFor(x => x.AssignmentsId).GreaterThan(0);
            }
        }
    }
}
