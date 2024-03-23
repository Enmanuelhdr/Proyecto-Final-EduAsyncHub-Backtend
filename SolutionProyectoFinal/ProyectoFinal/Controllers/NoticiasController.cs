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
    public class NoticiasController : ControllerBase
    {
        private readonly INoticiasService _noticiasService;

        public NoticiasController(INoticiasService noticiasService)
        {
            _noticiasService = noticiasService;
        }

        [HttpGet("VerNoticias")]
        public IActionResult GetNoticias()
        {
            try
            {
                var noticias = _noticiasService.MostrarTodasNoticias();
                return Ok(noticias);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener las noticias: {ex.Message}");
            }
        }

        [HttpPost("AgregarNoticia")]
        public IActionResult CrearNoticia([FromBody] Noticia nuevaNoticia)
        {
            try
            {
                _noticiasService.CrearNoticia(nuevaNoticia);
                return StatusCode(StatusCodes.Status201Created, "Noticia creada correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al crear la noticia: {ex.Message}");
            }
        }

        [HttpPut("EditarNoticia/{id}")]
        public IActionResult EditarNoticia(int id, [FromBody] Noticia noticiaEditada)
        {
            try
            {
                _noticiasService.EditarNoticia(id, noticiaEditada);
                return Ok("Noticia editada correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al editar la noticia: {ex.Message}");
            }
        }

        [HttpDelete("EliminarNoticia/{id}")]
        public IActionResult EliminarNoticia(int id)
        {
            try
            {
                _noticiasService.EliminarNoticia(id);
                return Ok("Noticia eliminada correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al eliminar la noticia: {ex.Message}");
            }
        }
    }
}
