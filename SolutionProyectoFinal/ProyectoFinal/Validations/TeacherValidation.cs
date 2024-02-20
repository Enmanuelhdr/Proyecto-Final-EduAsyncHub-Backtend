using FluentValidation;
using static ProyectoFinal.DTOs.StudentDTO;
using static ProyectoFinal.DTOs.TeacherDTO;

namespace ProyectoFinal.Validations
{
    public class TeacherValidation
    {
        public class TeachMatterValidator : AbstractValidator<TeachMatterRequestDto>
        {
            public TeachMatterValidator()
            {
                RuleFor(x => x.ProfesorId).GreaterThan(0);
                RuleFor(x => x.MateriaId).InclusiveBetween(1, 28);
            }
        }

        public class AllSubjectsTaughtValidator : AbstractValidator<AllSubjectsTaughtRequestDto>
        {
            public AllSubjectsTaughtValidator()
            {
                RuleFor(x => x.ProfesorId).GreaterThan(0);
            }
        }

        public class TaskPublishValidator : AbstractValidator<TaskPublishRequestDto>
        {
            public TaskPublishValidator()
            {
                RuleFor(x => x.ProfesorId).GreaterThan(0);
                RuleFor(x => x.MateriaId).InclusiveBetween(1, 28);
                RuleFor(x => x.Titulo).NotEmpty().Length(1, 100);
                RuleFor(x => x.Descripcion).NotEmpty().Length(1, 500);
                RuleFor(x => x.FechaVencimiento).NotEmpty();
            }
        }

        public class TaskUpdateValidator : AbstractValidator<TaskUpdatehRequestDto>
        {
            public TaskUpdateValidator()
            {
                RuleFor(x => x.TareaId).GreaterThan(0);
                RuleFor(x => x.ProfesorId).GreaterThan(0);
                RuleFor(x => x.MateriaId).GreaterThan(0);
                RuleFor(x => x.Titulo).NotEmpty().Length(1, 100);
                RuleFor(x => x.Descripcion).NotEmpty().Length(1, 500);
                RuleFor(x => x.FechaVencimiento).NotEmpty();
            }
        }

        public class TaskDeleteValidator : AbstractValidator<TaskDeleteRequestDto>
        {
            public TaskDeleteValidator()
            {
                RuleFor(x => x.TareaId).GreaterThan(0);
                RuleFor(x => x.ProfesorId).GreaterThan(0);
                RuleFor(x => x.MateriaId).GreaterThan(0);
            }
        }

    }
}
