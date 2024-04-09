using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Interfaces;
using ProyectoFinal.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentValidation.Results;
using ProyectoFinal.Validations;

namespace ProyectoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdmisionesController : ControllerBase
    {
        private readonly IAdmisionesService _admisionesService;
        private readonly IValidationsManager _validationsManager;

        public AdmisionesController(IAdmisionesService admisionesService, IValidationsManager validationsManager)
        {
            _admisionesService = admisionesService;
            _validationsManager = validationsManager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SolicitudAdmision>>> GetAdmisiones()
        {
            return await _admisionesService.GetAllAdmisiones();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SolicitudAdmision>> GetAdmision(int id)
        {
            var admision = await _admisionesService.GetAdmisionById(id);

            if (admision == null)
            {
                return NotFound();
            }

            return admision;
        }

        [HttpPost]
        public async Task<ActionResult<SolicitudAdmision>> PostAdmision(SolicitudAdmision admision)
        {
            var validator = new SolicitudAdmisionValidator();
            ValidationResult result = await validator.ValidateAsync(admision);

            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            await _admisionesService.CreateAdmision(admision);

            return CreatedAtAction("GetAdmision", new { id = admision.SolicitudId }, admision);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdmision(int id, SolicitudAdmision admision)
        {

            var validator = new SolicitudAdmisionValidator();
            ValidationResult result = await validator.ValidateAsync(admision);

            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            try
            {
                await _admisionesService.UpdateAdmision(id, admision);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdmision(int id)
        {
            try
            {
                await _admisionesService.DeleteAdmision(id);
                return NoContent();
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }

        [HttpPut("Approve/{id}")]
        public async Task<IActionResult> ApproveAdmision(int id, string comentario)
        {
            try
            {
                await _admisionesService.ApproveAdmision(id, comentario);
                return NoContent();
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }

        [HttpPut("Reject/{id}")]
        public async Task<IActionResult> RejectAdmision(int id, string comentario)
        {

            try
            {
                await _admisionesService.RejectAdmision(id, comentario);
                return NoContent();
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }
    }
}
