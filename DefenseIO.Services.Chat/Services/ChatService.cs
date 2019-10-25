using DefenseIO.Domain.Domains.Chatting;
using DefenseIO.Domain.Domains.Chatting.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DefenseIO.Services.Chat.Services
{
  public class ChatService
  {
    private readonly IChatMessageRepository _repository;

    public ChatService(IChatMessageRepository repository)
    {
      _repository = repository;
    }

    public async Task<ChatMessage> CreateNewMessage(string senderName, string message)
    {
      var chatMessage = new ChatMessage
      {
        Id = Guid.NewGuid(),
        ClientId = Guid.NewGuid(),
        Content = message
      };
      await _repository.Add(chatMessage);

      return chatMessage;
    }

    public async Task<IEnumerable<ChatMessage>> GetAllInitially()
    {
      return _repository.Query().AsEnumerable();
    }
  }
}
