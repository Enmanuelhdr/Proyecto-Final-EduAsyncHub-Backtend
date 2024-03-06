using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Interfaces;
using static ProyectoFinal.DTOs.TeacherDTO;

namespace ProyectoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        private readonly IValidationsManager _validationsManager;

        public TeacherController(ITeacherService teacherService, IValidationsManager validationsManager)
        {
            _teacherService = teacherService;
            _validationsManager = validationsManager;

        }

        //[Authorize(Roles = "Profesor")]
        [HttpPost("AsignarMaterias")]
        public async Task<IActionResult> TeachMatterSubject(TeachMatterRequestDto teacher)
        {
            var validation = await _validationsManager.ValidateAsync(teacher);

            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors);
            }

            var teacherExists = await _validationsManager.ValidateTeacherExistAsync(teacher.ProfesorId);

            if (!teacherExists)
            {
                return BadRequest("El profesor no existe.");
            }

            try
            {
                await _teacherService.TeachMatterSubject(teacher);
                return Ok("El profesor va impartir la materia exitosamente.");
            }

            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.InnerException);
            }
        }

        //[Authorize(Roles = "Profesor")]
        [HttpGet("MostrarMisMateriasImpartidas")]
        public async Task<IActionResult> AllSubjectsTaught([FromQuery] AllSubjectsTaughtRequestDto teacher)
        {
            var validation = await _validationsManager.ValidateAsync(teacher);

            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors);
            }

            var teacherExists = await _validationsManager.ValidateTeacherExistAsync(teacher.ProfesorId);

            if (!teacherExists)
            {
                return BadRequest("El profesor no existe.");
            }

            try
            {
                var lista = await _teacherService.AllSubjectsTaught(teacher);
                return Ok(lista);
            }

            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.InnerException);
            }
        }

        //[Authorize(Roles = "Profesor")]
        [HttpGet("MostrarMisEstudiantesPorMaterias")]
        public async Task<IActionResult> AllStudentsForSubjectsTaught([FromQuery] int teacherId)
        {

            var teacherExists = await _validationsManager.ValidateTeacherExistAsync(teacherId);

            if (!teacherExists)
            {
                return BadRequest("El profesor no existe.");
            }

            try
            {
                var lista = await _teacherService.ObtenerEstudiantesPorProfesor(teacherId);
                return Ok(lista);
            }

            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.InnerException);
            }
        }



        //[Authorize(Roles = "Profesor")]
        [HttpPost("PublicarAsistencia")]

        public async Task<IActionResult> PublishAssistance(AssistancePublishRequestDto assistance)
        {
            var validation = await _validationsManager.ValidateAsync(assistance);

            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors);
            }

            var teacherExists = await _validationsManager.ValidateTeacherExistAsync(assistance.ProfesorId);

            if (!teacherExists)
            {
                return BadRequest("El profesor no existe.");
            }

            var studentExists = await _validationsManager.ValidateStudentExistAsync(assistance.EstudianteId);

            if (!studentExists)
            {
                return BadRequest("El estudiante no existe.");
            }

            try
            {
                await _teacherService.PublishAssistance(assistance);
                return Ok("Se ha publicado la asistencia exitosamente.");

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex);
            }
        }

        //[Authorize(Roles = "Profesor")]
        [HttpPost("PublicarCalificacionesPeriodos")]
        public async Task<IActionResult> QualificationsStudents(QualificationsStudentRequestDto qualificationsStudent)
        {
            var validation = await _validationsManager.ValidateAsync(qualificationsStudent);

            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors);
            }

            var teacherExists = await _validationsManager.ValidateTeacherExistAsync(qualificationsStudent.ProfesorId);

            if (!teacherExists)
            {
                return BadRequest("El profesor no existe.");
            }

            var studentExists = await _validationsManager.ValidateStudentExistAsync(qualificationsStudent.EstudianteId);

            if (!studentExists)
            {
                return BadRequest("El estudiante no existe.");
            }

            var qualificationNotValid = await _validationsManager.ValidateQualificationExists(qualificationsStudent);

            if (qualificationNotValid)
            {
                return BadRequest("Nota del periodo ya existe.");
            }

            try
            {
                await _teacherService.QualificationsStudents(qualificationsStudent);
                return Ok("Se ha publicado la calificación exitosamente.");
            }

            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex);
            }
        }
    }
}
