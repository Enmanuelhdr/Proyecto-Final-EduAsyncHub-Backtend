using FluentValidation.Results;


namespace ProyectoFinal.Interfaces
{
    public interface IValidationsManager
    {
        Task<ValidationResult> ValidateAsync<T>(T entity);

        Task<bool> ValidateEmailExistAsync(string email);

        Task<bool> ValidateUserExistAsync(int userId);

        Task<bool> ValidateStudentExistAsync(int studentId);


    }
}
