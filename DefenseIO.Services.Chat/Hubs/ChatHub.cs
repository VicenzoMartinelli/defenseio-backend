using DefenseIO.Domain.Domains.Chatting;
using DefenseIO.Domain.Domains.Chatting.Interfaces;
using DefenseIO.Domain.Domains.Users;
using DefenseIO.Domain.Domains.Users.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace DefenseIO.Services.Chat.Hubs
{
  [Authorize]
  public class ChatHub : Hub
  {
    private readonly IChatMessageRepository _chatRepository;
    private readonly ILoggedUserAcessor _acessor;

    public ChatHub(IChatMessageRepository chatRepository, ILoggedUserAcessor acessor)
    {
      _chatRepository = chatRepository;
      _acessor = acessor;
    }

    public async Task SendChatMessage(ChatMessage msg)
    {
      if (_acessor.Type == UserType.Provider)
      {
        msg.ProviderId = _acessor.UserId;
      }
      else
      {
        msg.ClientId = _acessor.UserId;
      }

      msg.SenderName = _acessor.Name;

      await _chatRepository.Add(msg);
      await _chatRepository.SaveChanges();

      await Clients.User(_acessor.Type == UserType.Provider ? msg.ClientId.ToString() : msg.ProviderId.ToString())
        .SendAsync("receiveChatMessage", msg);
    }
  }
}
