using Microsoft.AspNetCore.SignalR;

namespace HolaGuide.Hubs
{
    public class ServiceHub : Hub
    {
        public async Task NewServiceCreated()
        {
            await Clients.All.SendAsync("AlertNewServiceCreated", "New service has been added. Please reload the page to view changes!");
        }
    }
}
