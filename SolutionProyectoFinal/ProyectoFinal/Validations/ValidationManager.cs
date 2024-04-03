using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using static ProyectoFinal.DTOs.UsuarioDTO;
using ProyectoFinal.Interfaces;
using static ProyectoFinal.DTOs.TeacherDTO;
using static ProyectoFinal.DTOs.FiltrosDTO;
using ProyectoFinal.Context;
using ProyectoFinal.Models;



namespace ProyectoFinal.Validations
{

    public class ValidationsManager : IValidationsManager
    {

            private readonly EduAsyncHubContext _context;
            private readonly Dictionary<Type, IValidator> _dictionary;

            public ValidationsManager(
                EduAsyncHubContext context,
                IValidator<RegisterUserRequestDto> validatorRegisterUser,
                IValidator<LoginUserRequestDto> validatorLoginUser,
                IValidator<UpdateUserRequestDto> validatorUpdateUser,
                IValidator<DeleteUserRequestDto> validatorDeleteUser,
                IValidator<TeachMatterRequestDto> validateTeachMatter,
                IValidator<AssistancePublishRequestDto> validatorAssistance,
                IValidator<QualificationsStudentRequestDto> validatorQualificationStudent,
                IValidator<UserFilterRequestDto> validatorFilterUser,
                IValidator<SubjectFilterRequestDto> validatorFilterSubject,
                IValidator<UpdateProfileRequestDto> validatorUpdateProfile,
                IValidator<TeachStudentsRequestDto> validatorTeacherStudents



                )
        {
                _context = context;
                _dictionary = new()
            {
                { typeof(RegisterUserRequestDto), validatorRegisterUser },
                { typeof(LoginUserRequestDto), validatorLoginUser },
                { typeof(UpdateUserRequestDto), validatorUpdateUser },
                { typeof(DeleteUserRequestDto), validatorDeleteUser },
                { typeof(TeachMatterRequestDto), validateTeachMatter },
                { typeof(AssistancePublishRequestDto), validatorAssistance },
                { typeof(QualificationsStudentRequestDto), validatorQualificationStudent },
                { typeof(UserFilterRequestDto), validatorFilterUser },
                { typeof(SubjectFilterRequestDto), validatorFilterSubject },
                { typeof(UpdateProfileRequestDto), validatorUpdateProfile },
                { typeof(TeachStudentsRequestDto), validatorTeacherStudents }
            };
            }

            public async Task<ValidationResult> ValidateAsync<T>(T entity)
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity), "Entity cannot be null");
                }

                if (_dictionary.TryGetValue(typeof(T), out var value) && value is IValidator<T> validator)
                {
                    var result = await validator.ValidateAsync(entity);
                    return result;
                }

                throw new InvalidOperationException($"Validator not registered for type {typeof(T)}. Please register a validator for this type.");
            }

        public async Task<bool> ValidateUserExistAsync(string userId)
        {
            var accountExists = await _context.Usuarios.AnyAsync(account => account.UsuarioId == userId);

            return accountExists;
        }

        public async Task<bool> ValidateStudentExistAsync(string userId)
        {
            var studentExist = await _context.Estudiantes.AnyAsync(u => u.UsuarioId == userId);

            return studentExist;
        }

        public async Task<bool> ValidateTeacherExistAsync(string userId)
        {
            var teacherExist = await _context.Profesores.AnyAsync(u => u.UsuarioId == userId);

            return teacherExist;
        }

        public async Task<bool> ValidateEmailExistAsync(string email)
        {
            var emailExists = await _context.Usuarios.AnyAsync(account => account.CorreoElectronico == email);

            return emailExists;
        }

        public async Task<bool> ValidateUserEmailIsYourAsync(string userId, string email)
        {
            var emailExists = await _context.Usuarios.AnyAsync(account => account.CorreoElectronico == email && account.UsuarioId == userId);

            return emailExists;
        }

        public async Task<bool> ValidateQualificationExists(QualificationsStudentRequestDto qualificationsStudent)
        {
            var studentId = await _context.Estudiantes
                .Where(e => e.UsuarioId == qualificationsStudent.StundentUserId)
                .Select(e => e.EstudianteId)
                .FirstOrDefaultAsync();

            var teacherId = await _context.Profesores
                .Where(p => p.UsuarioId == qualificationsStudent.TeacherUserId)
                .Select(p => p.ProfesorId)
                .FirstOrDefaultAsync();

            if (studentId != 0 && teacherId != 0)
            {
                var exists = await _context.Calificaciones
                    .AnyAsync(c => c.EstudianteId == studentId &&
                                   c.MateriaId == qualificationsStudent.MateriaId &&
                                   c.Periodo == qualificationsStudent.Periodo);

                return exists;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> ProfesorImparteMateria(string userId, int materiaId, int gradoId)
        {
            var profesorImparte = await _context.ProfesorMateria
                .AnyAsync(pm => pm.Profesor.UsuarioId == userId && pm.MateriaId == materiaId && pm.GradoId == gradoId);

            return profesorImparte;
        }



    }
}

