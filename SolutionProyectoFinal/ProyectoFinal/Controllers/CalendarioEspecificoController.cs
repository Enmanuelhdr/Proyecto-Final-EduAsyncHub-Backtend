
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Interfaces;
using ProyectoFinal.Models;
using System;

namespace ProyectoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarioEspecificoController : ControllerBase
    {
        private readonly ICalendarioEspecificoService _calendarioService;

        public CalendarioEspecificoController(ICalendarioEspecificoService calendarioService)
        {
            _calendarioService = calendarioService;
        }

        [HttpPost("AgregarActividad")]
        public IActionResult CrearActividad( CalendarioEspecifico nuevaActividad)
        {
            try
            {
                _calendarioService.CrearActividad(nuevaActividad);
                return StatusCode(StatusCodes.Status201Created, "Actividad creada correctamente");
            }
            catch (Exception ex)
            {
                // Captura la excepción interna
                var innerException = ex.InnerException != null ? ex.InnerException.Message : "";
                var errorMessage = $"Error al crear la actividad: {ex.Message}. Detalles: {innerException}";

                // Registra el mensaje de error
                Console.WriteLine(errorMessage);

                return StatusCode(StatusCodes.Status500InternalServerError, errorMessage);
            }
        }


        [HttpPut("EditarActividad/{id}")]
        public IActionResult EditarActividad(int id, CalendarioEspecifico actividadEditada)
        {
            try
            {
                _calendarioService.EditarActividad(id, actividadEditada);
                return Ok("Actividad editada correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al editar la actividad: {ex.Message}");
            }
        }
        [HttpGet("MostrarActividades")]
        public IActionResult MostrarActividades()
        {
            try
            {
                var actividades = _calendarioService.MostrarTodasLasActividades();
                return Ok(actividades);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al mostrar las actividades: {ex.Message}");
            }
        }
        [HttpDelete("EliminarActividad/{id}")]
        public IActionResult EliminarActividad(int id)
        {
            try
            {
                _calendarioService.EliminarActividad(id);
                return Ok("Actividad eliminada correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al eliminar la actividad: {ex.Message}");
            }
        }


    }
}
