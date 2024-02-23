using Microsoft.AspNetCore.SignalR;
using ProyectoFinal.Context;

namespace ProyectoFinal.Services
{
    public class ChatService : Hub
    {
        private readonly EduAsyncHubContext _dbContext;

        public ChatService(EduAsyncHubContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SendMessage(string room, string user, string message, int sectionId)
        {
            await Clients.Group($"{room}-{sectionId}").SendAsync("RecibirMensaje", user, message);
        }

        public async Task AddToGroup(string room, int sectionId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, $"{room}-{sectionId}");

            await Clients.Groups($"{room}-{sectionId}").SendAsync("ShowWho", $"Alguien se conectó a la sección {sectionId}");
        }
    }
}
