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
        [HttpPost("CrearTarea")]
        public async Task<IActionResult> CreateTask(TaskPublishRequestDto task)
        {
            var validation = await _validationsManager.ValidateAsync(task);

            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors);
            }

            var teacherExists = await _validationsManager.ValidateTeacherExistAsync(task.ProfesorId);

            if (!teacherExists)
            {
                return BadRequest("El profesor no existe.");
            }

            var subjectExists = await _validationsManager.ValidateTeacherSubjectExistAsync(task.ProfesorId, task.MateriaId);

            if (!subjectExists)
            {
                return BadRequest("El profesor no tiene asignada esta materia o no existe.");
            }

            try
            {
                await _teacherService.CreateTask(task);
                return Ok("Se ha publicado la tarea exitosamente.");
            }

            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex);
            }
        }

        //[Authorize(Roles = "Profesor")]
        [HttpPut("EditarTarea")]
        public async Task<IActionResult> UpdateTask(TaskUpdatehRequestDto updateTask)
        {
            var validation = await _validationsManager.ValidateAsync(updateTask);

            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors);
            }

            var teacherExists = await _validationsManager.ValidateTeacherExistAsync(updateTask.ProfesorId);

            if (!teacherExists)
            {
                return BadRequest("El profesor no existe.");
            }

            var subjectExists = await _validationsManager.ValidateTeacherSubjectExistAsync(updateTask.ProfesorId, updateTask.MateriaId);

            if (!subjectExists)
            {
                return BadRequest("El profesor no tiene asignada esta materia o no existe.");
            }

            var taskExists = await _validationsManager.ValidateTaskExistAsync(updateTask.TareaId);

            if (!taskExists)
            {
                return BadRequest("No existe nignuna tarea con este id relacionado.");
            }

            try
            {
                await _teacherService.UpdateTask(updateTask);
                return Ok("Se ha editado la tarea exitosamente.");
            }

            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex);
            }
        }

        //[Authorize(Roles = "Profesor")]
        [HttpDelete("EliminarTarea")]
        public async Task<IActionResult> DeleteTask(TaskDeleteRequestDto deleteTask)
        {
            var validation = await _validationsManager.ValidateAsync(deleteTask);

            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors);
            }

            var teacherExists = await _validationsManager.ValidateTeacherExistAsync(deleteTask.ProfesorId);

            if (!teacherExists)
            {
                return BadRequest("El profesor no existe.");
            }

            var subjectExists = await _validationsManager.ValidateTeacherSubjectExistAsync(deleteTask.ProfesorId, deleteTask.MateriaId);

            if (!subjectExists)
            {
                return BadRequest("El profesor no tiene asignada esta materia o no existe.");
            }

            var taskExists = await _validationsManager.ValidateTaskExistAsync(deleteTask.TareaId);

            if (!taskExists)
            {
                return BadRequest("No existe nignuna tarea con este id relacionado.");
            }

            try
            {
                await _teacherService.DeleteTask(deleteTask);
                return Ok("Se ha eliminado la tarea exitosamente.");
            }

            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex);
            }
        }

        //[Authorize(Roles = "Profesor")]
        [HttpPut("CalificarTarea")]
        public async Task<IActionResult> QualificationAssignments(QualificationsAssignmentsRequestDTO qualificationAssignments)
        {
            var validation = await _validationsManager.ValidateAsync(qualificationAssignments);

            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors);
            }

            try
            {
                await _teacherService.QualificationsAssignments(qualificationAssignments);
                return Ok("Se ha calificado la tarea exitosamente.");
            }

            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex);
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
        [HttpPost("PublicarCalificacionesTotales")]
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
