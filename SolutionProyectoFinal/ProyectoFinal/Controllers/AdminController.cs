using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Interfaces;
using static ProyectoFinal.DTOs.UsuarioDTO;

namespace ProyectoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly IValidationsManager _validationsManager;

        public AdminController(IAdminService adminService, IValidationsManager validationsManager)
        {
            _adminService = adminService;
            _validationsManager = validationsManager;
        }

        [HttpPut("EditarUsuarioAdmin/{id}")]
        public async Task<IActionResult> EditAnyUserAdmin(int id, UpdateUserRequestDto usuario)
        {
            var validation = await _validationsManager.ValidateAsync(usuario);

            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors);
            }

            var userExists = await _validationsManager.ValidateUserExistAsync(id);

            if (!userExists)
            {
                return BadRequest("El usuario no existe.");
            }

            try
            {
                await _adminService.EditAnyUserAdmin(id, usuario);
                return Ok("Usuario editado exitosamente.");
            }

            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }

        [HttpDelete("EliminarUsuarioAdmin")]
        public async Task<IActionResult> DeleteAnyUserAdmin(DeleteUserRequestDto usuario)
        {
            var validation = await _validationsManager.ValidateAsync(usuario);

            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors);
            } 

            var userExists = await _validationsManager.ValidateUserExistAsync(usuario.UserId);

            if (!userExists)
            {
                return BadRequest("El usuario no existe.");
            }

            try
            {
                await _adminService.DeleteAnyUserAdmin(usuario);
                return Ok("El usuario ha sido eliminado");
            }

            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }

        [HttpGet("ObtenerUsuarios")]
        public async Task<IActionResult> GetAllUsuarios()
        {
            try
            {
                var usuarios = await _adminService.GetAllUsuarios();
                return Ok(usuarios);
            }

            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }

        [HttpGet("ObtenerEstudiantes")]
        public async Task<IActionResult> GetEstudiantes()
        {
            try
            {
                var estudiantes = await _adminService.GetEstudiantes();
                return Ok(estudiantes);
            }

            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }

        [HttpGet("ObtenerProfesores")]
        public async Task<IActionResult> GetProfesores()
        {
            try
            {
                var profesores = await _adminService.GetProfesores();
                return Ok(profesores);
            }

            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }
    }
}
