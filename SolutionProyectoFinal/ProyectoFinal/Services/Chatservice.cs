using Microsoft.AspNetCore.SignalR;
using ProyectoFinal.Context;

namespace ProyectoFinal.Services
{
    public class ChatService : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("RecibirMensaje", user, message);
        }
    }
}
