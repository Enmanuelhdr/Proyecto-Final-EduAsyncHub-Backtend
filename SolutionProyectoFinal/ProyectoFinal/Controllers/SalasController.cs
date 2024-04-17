using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Interfaces;
using ProyectoFinal.Models;
using static ProyectoFinal.DTOs.SalasDTOcs;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProyectoFinal.DTOs;

namespace ProyectoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalasController : ControllerBase
    {
        private readonly ISalasService _salasService;

        public SalasController(ISalasService salasService)
        {
            _salasService = salasService;
        }

        [HttpPost]
        public async Task<IActionResult> CrearSala([FromBody] SalasDTOcs salaDto)
        {
            try
            {

                await _salasService.CrearSalaAsync(salaDto);
                return Ok("Sala creada exitosamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear la sala: {ex.Message}");
            }
        }


        [HttpGet]
        public async Task<IActionResult> ObtenerSalas()
        {
            try
            {
                var salas = await _salasService.ObtenerSalasAsync();
                return Ok(salas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener las salas: {ex.Message}");
            }
        }
    }
}
