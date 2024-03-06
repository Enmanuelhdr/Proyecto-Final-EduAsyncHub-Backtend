using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Interfaces;
using static ProyectoFinal.DTOs.FiltrosDTO;

namespace ProyectoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FiltroController : ControllerBase
    {
        private readonly IFiltrosService _filtrosService;
        private readonly IValidationsManager _validationsManager;

        public FiltroController(IFiltrosService filtrosService, IValidationsManager validationsManager)
        {
            _filtrosService = filtrosService;
            _validationsManager = validationsManager;
        }

        [HttpGet("ObtenerUsuarioPorID")]
        public async Task<IActionResult> GetUserForId([FromQuery] UserFilterRequestDto userFilter)
        {
            var validation = await _validationsManager.ValidateAsync(userFilter);

            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors);
            }

            var userExists = await _validationsManager.ValidateUserExistAsync(userFilter.UserId);

            if (!userExists)
            {
                return BadRequest("El usuario no existe.");
            }

            try
            {
                var student = await _filtrosService.GetUserForId(userFilter);
                return Ok(student);
            }

            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }

        [HttpGet("ObtenerEstudiantePorID")]
        public async Task<IActionResult> GetStudentForId([FromQuery] UserFilterRequestDto studentFilter)
        {
            var validation = await _validationsManager.ValidateAsync(studentFilter);

            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors);
            }

            var studentExists = await _validationsManager.ValidateUserExistAsync(studentFilter.UserId);

            if (!studentExists)
            {
                return BadRequest("El estudiante no existe.");
            }

            try
            {
                var student = await _filtrosService.GetStudentForId(studentFilter);
                return Ok(student);
            }

            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }

        [HttpGet("ObtenerProfesorPorID")]
        public async Task<IActionResult> GetTeacherForId([FromQuery] UserFilterRequestDto teacherFilter)
        {
            var validation = await _validationsManager.ValidateAsync(teacherFilter);

            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors);
            }

            var teacherExists = await _validationsManager.ValidateUserExistAsync(teacherFilter.UserId);

            if (!teacherExists)
            {
                return BadRequest("El profesor no existe.");
            }

            try
            {
                var teacher = await _filtrosService.GetTeacherForId(teacherFilter);
                return Ok(teacher);
            }

            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }


        [HttpGet("ObtenerMateriaPorID")]
        public async Task<IActionResult> GetSubjectForId([FromQuery] SubjectFilterRequestDto subjectFilter)
        {
            var validation = await _validationsManager.ValidateAsync(subjectFilter);

            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors);
            }

            try
            {
                var subject = await _filtrosService.GetSubjectForId(subjectFilter);
                return Ok(subject);
            }

            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }
    }
}
