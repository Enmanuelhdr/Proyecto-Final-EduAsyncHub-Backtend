using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Interfaces;
using ProyectoFinal.Models;

namespace ProyectoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly IEventoService _eventoService;

        public EventoController(IEventoService eventoService)
        {
            _eventoService = eventoService;
        }

        [HttpGet("VerEvento")]
        public IActionResult GetEvento()
        {
            try
            {
                var Eventos = _eventoService.MostrarTodosLosEventos();
                return Ok(Eventos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener los eventos: {ex.Message}");
            }
        }

        [HttpPost("AgregarEvento")]
        public IActionResult CrearEvento([FromBody] Evento nuevoEvento)
        {
            try
            {
                _eventoService.CrearEvento(nuevoEvento);
                return StatusCode(StatusCodes.Status201Created, "Evento creado correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al crear la Evento: {ex.Message}");
            }
        }

        [HttpPut("EditarEvento/{id}")]
        public IActionResult EditarEvento(int id, [FromBody] Evento EventoEditado)
        {
            try
            {
                _eventoService.EditarEvento(id, EventoEditado);
                return Ok("Evento editado correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al editar la Evento: {ex.Message}");
            }
        }

        [HttpDelete("EliminarEvento/{id}")]
        public IActionResult EliminarEvento(int id)
        {
            try
            {
                _eventoService.EliminarEvento(id);
                return Ok("Evento eliminado correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al eliminar la Evento: {ex.Message}");
            }
        }
    }
}
