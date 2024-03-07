using FluentValidation;
using ProyectoFinal.Validations;
using static ProyectoFinal.DTOs.UsuarioDTO;
using static ProyectoFinal.DTOs.TeacherDTO;
using static ProyectoFinal.Validations.TeacherValidation;
using static ProyectoFinal.DTOs.FiltrosDTO;
using static ProyectoFinal.Validations.FiltrosValidation;



namespace ProyectoFinal.Configuration
{
    public static class ValidatorsDependencies
    {
        public static void ValidatorsInjections(this IServiceCollection services)
        {
            //User
            services.AddScoped<IValidator<RegisterUserRequestDto>, RegisterUserValidator>();
            services.AddScoped<IValidator<LoginUserRequestDto>, LoginUserValidator>();
            services.AddScoped<IValidator<UpdateUserRequestDto>, UpdateUserValidator>();
            services.AddScoped<IValidator<DeleteUserRequestDto>, DeleteUserValidator>();
            services.AddScoped<IValidator<TeachMatterRequestDto>, TeachMatterValidator>();
            services.AddScoped<IValidator<AssistancePublishRequestDto>, AssistancePublishValidator>();
            services.AddScoped<IValidator<QualificationsStudentRequestDto>, QualificationsStudentValidator>();
            services.AddScoped<IValidator<UserFilterRequestDto>, UserFilterValidator>();
            services.AddScoped<IValidator<SubjectFilterRequestDto>, SubjectFilterValidator>();
            services.AddScoped<IValidator<UpdateProfileRequestDto>, UpdateProfileValidator>();

        }
    }
}
