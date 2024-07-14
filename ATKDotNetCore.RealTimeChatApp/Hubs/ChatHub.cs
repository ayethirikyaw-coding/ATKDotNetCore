using Microsoft.AspNetCore.SignalR;

namespace ATKDotNetCore.RealTimeChatApp.Hubs;

public class ChatHub : Hub
{
	//SendMessage
	public async Task ServerReceiveMessage(string user, string message)
	{
		await Clients.All.SendAsync("ClientReceiveMessage", user, message);
	}
}
