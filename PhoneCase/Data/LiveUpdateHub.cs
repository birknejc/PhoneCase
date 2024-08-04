using Microsoft.AspNetCore.SignalR;

namespace PhoneCase.Data
{
    public class LiveUpdateHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("Receive Message", user, message);
        }
    }
}
