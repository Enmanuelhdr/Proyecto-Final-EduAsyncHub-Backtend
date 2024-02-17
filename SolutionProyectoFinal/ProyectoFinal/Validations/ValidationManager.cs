using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using static ProyectoFinal.DTOs.UsuarioDTO;
using ProyectoFinal.Context;
using ProyectoFinal.Interfaces;


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
                IValidator<AssignPermissionsUserRequestDto> validateAssignPermissions





                )
        {
                _context = context;
                _dictionary = new()
            {
                { typeof(RegisterUserRequestDto), validatorRegisterUser },
                { typeof(LoginUserRequestDto), validatorLoginUser },
                { typeof(UpdateUserRequestDto), validatorUpdateUser },
                { typeof(DeleteUserRequestDto), validatorDeleteUser },
                { typeof(AssignPermissionsUserRequestDto), validateAssignPermissions },

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

        public async Task<bool> ValidateUserExistAsync(int userId)
        {
            var accountExists = await _context.Usuarios.AnyAsync(account => account.UsuarioId == userId);

            return accountExists;
        }

        public async Task<bool> ValidateEmailExistAsync(string email)
            {
                var emailExists = await _context.Usuarios.AnyAsync(account => account.CorreoElectronico == email);

                return emailExists;
            }



    }
}

