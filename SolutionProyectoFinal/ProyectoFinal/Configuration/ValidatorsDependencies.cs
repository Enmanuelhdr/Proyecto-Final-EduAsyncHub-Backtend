using FluentValidation;
using ProyectoFinal.Validations;
using static ProyectoFinal.DTOs.UsuarioDTO;
using static ProyectoFinal.DTOs.StudentDTO;
using static ProyectoFinal.Validations.StudentValidation;
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
            services.AddScoped<IValidator<AssignPermissionsUserRequestDto>, AssignUserValidator>();
            services.AddScoped<IValidator<EnrollCareerStudentRequestDto>, EnrollCareerStudentValidator>();
            services.AddScoped<IValidator<EnrollSubjectStudentRequestDto>, EnrollSubjectStudentValidator>();
            services.AddScoped<IValidator<TeachMatterRequestDto>, TeachMatterValidator>();
            services.AddScoped<IValidator<AllSubjectsTaughtRequestDto>, AllSubjectsTaughtValidator>();
            services.AddScoped<IValidator<AllSubjectsStudentRequestDto>, AllSubjectsStudentValidator>();
            services.AddScoped<IValidator<TaskPublishRequestDto>, TaskPublishValidator>();
            services.AddScoped<IValidator<TaskUpdatehRequestDto>, TaskUpdateValidator>();
            services.AddScoped<IValidator<TaskDeleteRequestDto>, TaskDeleteValidator>();
            services.AddScoped<IValidator<SubmitAssignmentRequestDto>, SubmitAssignmentValidator>();
            services.AddScoped<IValidator<EditAssignmentRequestDto>, EditAssignmentValidator>();
            services.AddScoped<IValidator<DeleteAssignmentRequestDto>, DeleteAssignmentValidator>();
            services.AddScoped<IValidator<QualificationsAssignmentsRequestDTO>, QualificationsAssignmentsValidator>();
            services.AddScoped<IValidator<AssistancePublishRequestDto>, AssistancePublishValidator>();
            services.AddScoped<IValidator<QualificationsStudentRequestDto>, QualificationsStudentValidator>();
            services.AddScoped<IValidator<ViewQualificationsRequestDto>, ViewQualificationsValidator>();
            services.AddScoped<IValidator<ViewAssitanceRequestDto>, ViewAssitanceValidator>();
            services.AddScoped<IValidator<UserFilterRequestDto>, UserFilterValidator>();
            services.AddScoped<IValidator<StudentFilterRequestDto>, StudentFilterValidator>();
            services.AddScoped<IValidator<TeacherFilterRequestDto>, TeacherFilterValidator>();
            services.AddScoped<IValidator<CareerFilterRequestDto>, CareerFilterValidator>();
            services.AddScoped<IValidator<SubjectFilterRequestDto>, SubjectFilterValidator>();
            services.AddScoped<IValidator<AssignmentsFilterRequestDto>, AssignmentsFilterValidator>();
            services.AddScoped<IValidator<UpdateProfileRequestDto>, UpdateProfileValidator>();









        }
    }
}
