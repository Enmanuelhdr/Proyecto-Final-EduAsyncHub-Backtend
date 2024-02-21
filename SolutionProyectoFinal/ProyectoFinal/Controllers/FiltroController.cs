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
    }
}
