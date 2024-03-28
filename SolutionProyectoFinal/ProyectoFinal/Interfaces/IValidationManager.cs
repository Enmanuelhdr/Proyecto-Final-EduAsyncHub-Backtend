using FluentValidation.Results;
using static ProyectoFinal.DTOs.TeacherDTO;


namespace ProyectoFinal.Interfaces
{
    public interface IValidationsManager
    {
        Task<ValidationResult> ValidateAsync<T>(T entity);

        Task<bool> ValidateEmailExistAsync(string email);

        Task<bool> ValidateUserExistAsync(string userId);

        Task<bool> ValidateStudentExistAsync(string studentId);

        Task<bool> ValidateTeacherExistAsync(string teacherId);

        Task<bool> ValidateQualificationExists(QualificationsStudentRequestDto qualificationsStudent);

        Task<bool> ValidateUserEmailIsYourAsync(string userId, string email);

        Task<bool> ProfesorImparteMateria(string userId, int materiaId, int gradoId);
    }
}
