using DefenseIO.Services.Chat.Models;
using DefenseIO.Services.Chat.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DefenseIO.Services.Chat.Services
{
  public class ChatService
  {
    private readonly ChatRepository _repository;

    public ChatService(ChatRepository repository)
    {
      _repository = repository;
    }

    public async Task<ChatMessage> CreateNewMessage(string senderName, string message)
    {
      var chatMessage = new ChatMessage
      {
        Id = Guid.NewGuid().ToString(),
        Sender = senderName,
        Message = message
      };
      await _repository.AddMessage(chatMessage);

      return chatMessage;
    }

    public async Task<IEnumerable<ChatMessage>> GetAllInitially()
    {
      return await _repository.GetTopMessages();
    }
  }
}
