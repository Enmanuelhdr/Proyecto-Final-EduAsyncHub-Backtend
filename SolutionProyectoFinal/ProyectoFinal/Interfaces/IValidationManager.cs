using FluentValidation.Results;
using static ProyectoFinal.DTOs.TeacherDTO;


namespace ProyectoFinal.Interfaces
{
    public interface IValidationsManager
    {
        Task<ValidationResult> ValidateAsync<T>(T entity);

        Task<bool> ValidateEmailExistAsync(string email);

        Task<bool> ValidateUserExistAsync(int userId);

        Task<bool> ValidateStudentExistAsync(int studentId);

        Task<bool> ValidateTeacherExistAsync(int teacherId);

        Task<bool> ValidateQualificationExists(QualificationsStudentRequestDto qualificationsStudent);


    }
}
