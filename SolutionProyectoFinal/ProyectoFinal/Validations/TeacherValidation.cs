﻿using FluentValidation;
using static ProyectoFinal.DTOs.TeacherDTO;

namespace ProyectoFinal.Validations
{
    public class TeacherValidation
    {
        public class TeachMatterValidator : AbstractValidator<TeachMatterRequestDto>
        {
            public TeachMatterValidator()
            {
                RuleFor(x => x.TeacherUserId).NotEmpty();
                RuleFor(x => x.MateriaId).InclusiveBetween(1, 12);
                RuleFor(x => x.GradoId).InclusiveBetween(1, 12);

            }
        }

        public class TeachStudentsValidator : AbstractValidator<TeachStudentsRequestDto>
        {
            public TeachStudentsValidator()
            {
                RuleFor(x => x.MateriaId).InclusiveBetween(1, 12);
                RuleFor(x => x.GradoId).InclusiveBetween(1, 12);

            }
        }

        public class AssistancePublishValidator : AbstractValidator<AssistancePublishRequestDto>
        {
            public AssistancePublishValidator()
            {
                RuleFor(x => x.StundentUserId).NotEmpty();
                RuleFor(x => x.MateriaId).GreaterThan(0);
                RuleFor(x => x.TeacherUserId).NotEmpty();
                RuleFor(x => x.Asistio).NotNull();
                
            }
        }

        public class QualificationsStudentValidator : AbstractValidator<QualificationsStudentRequestDto>
        {
            public QualificationsStudentValidator()
            {
                RuleFor(x => x.StundentUserId).NotEmpty();
                RuleFor(x => x.MateriaId).GreaterThan(0);
                RuleFor(x => x.TeacherUserId).NotEmpty();
                RuleFor(x => x.Calificacion).InclusiveBetween(0, 100);
                RuleFor(x => x.Periodo).InclusiveBetween(1, 4);
            }
        }



    }
}
