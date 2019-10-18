using DefenseIO.Services.Chat.Services;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace DefenseIO.Services.Chat.Hubs
{
  public class ChatHub : Hub
  {
    private readonly ChatService _chatService;

    public ChatHub(ChatService chatService)
    {
      _chatService = chatService;
    }

    public async Task AddMessage(string message)
    {
      var username = "usuario mair top que deveria vir do banco";
      var chatMessage = await _chatService.CreateNewMessage(username, message);

      // Call the MessageAdded method to update clients.
      await Clients.All.SendAsync("MessageAdded", chatMessage);
    }
  }
}
