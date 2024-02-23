using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Context;
using ProyectoFinal.Models;
using ProyectoFinal.Services;

namespace ProyectoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IHubContext<ChatService> _hubContext;
        private readonly EduAsyncHubContext _context;

        public ChatController(IHubContext<ChatService> hubContext, EduAsyncHubContext context)
        {
            _hubContext = hubContext;
            _context = context;
        }

        [HttpPost("EnviarMensaje")]
        public async Task<IActionResult> EnviarMensaje(int usuario, string mensaje)
        {
            var mensajeDto = new Mensaje
            {
                UsuarioId = usuario,
                Mensaje1 = mensaje,
                FechaEnvio = DateTime.UtcNow
            };

            _context.Mensajes.Add(mensajeDto);
            await _context.SaveChangesAsync();

            // Envía el mensaje a todos los usuarios conectados
            await _hubContext.Clients.All.SendAsync("RecibirMensaje", usuario, mensaje);

            return Ok(mensajeDto);
        }


        [HttpPost("UnirseAlChat")]
        public async Task<IActionResult> UnirseAlChat(int usuario, int sectionId)
        {
            // Lógica para unirse al chat
            // Puedes implementar la lógica necesaria para verificar si el usuario y la sección son válidos, etc.

            // Agregar al usuario al grupo de SignalR
            await _hubContext.Clients.Group($"{usuario}-{sectionId}").SendAsync("ShowWho", $"Alguien se conectó a la sección {sectionId}");

            return Ok($"Te has unido al chat de la sección {sectionId}");
        }
    }
}
