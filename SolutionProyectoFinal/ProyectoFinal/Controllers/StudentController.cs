using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Interfaces;
using ProyectoFinal.Services;
using static ProyectoFinal.DTOs.FiltrosDTO;
using static ProyectoFinal.DTOs.TeacherDTO;

namespace ProyectoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly IStudentService _studentService;
        private readonly IValidationsManager _validationsManager;

        public StudentController(IStudentService studentService, IValidationsManager validationsManager)
        {
            _studentService = studentService;
            _validationsManager = validationsManager;

        }

        //[Authorize(Roles = "Estudiante")]
        [HttpGet("MostrarMisMaterias")]
        public async Task<IActionResult> AllSubjectsTaught([FromQuery] UserFilterRequestDto student)
        {
            var validation = await _validationsManager.ValidateAsync(student);

            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors);
            }

            var studentExists = await _validationsManager.ValidateStudentExistAsync(student.UserId);

            if (!studentExists)
            {
                return BadRequest("El estudiante no existe.");
            }

            try
            {
                var lista = await _studentService.SubjectsEnrolledByStudent(student);
                return Ok(lista);
            }

            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.InnerException);
            }
        }

        //[Authorize(Roles = "Estudiante")]
        [HttpGet("VerMisCalificaciones")]
        public async Task<IActionResult> ViewQualifications([FromQuery] UserFilterRequestDto student)
        {
            var validation = await _validationsManager.ValidateAsync(student);

            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors);
            }

            var studentExists = await _validationsManager.ValidateStudentExistAsync(student.UserId);

            if (!studentExists)
            {
                return BadRequest("El estudiante no existe.");
            }

            try
            {
                var lista = await _studentService.ViewQualifications(student);
                return Ok(lista);
            }

            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.InnerException);
            }
        }

        //[Authorize(Roles = "Estudiante")]
        [HttpGet("VerMisAsistencias")]
        public async Task<IActionResult> ViewAssitance([FromQuery] UserFilterRequestDto student)
        {
            var validation = await _validationsManager.ValidateAsync(student);

            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors);
            }

            var studentExists = await _validationsManager.ValidateStudentExistAsync(student.UserId);

            if (!studentExists)
            {
                return BadRequest("El estudiante no existe.");
            }

            try
            {
                var lista = await _studentService.ViewAssitance(student);
                return Ok(lista);
            }

            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.InnerException);
            }
        }

    }
}
