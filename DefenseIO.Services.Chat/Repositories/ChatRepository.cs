using DefenseIO.Services.Chat.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DefenseIO.Services.Chat.Repositories
{
  public class ChatRepository
  {
    private static List<ChatMessage> _store = new List<ChatMessage>();
    public async Task<IEnumerable<ChatMessage>> GetTopMessages(int number = 100)
    {
      return _store.Take(100);
    }
    public async Task AddMessage(ChatMessage message)
    {
      var chatMessage = new ChatMessage
      {
        Id = message.Id,
        Message = message.Message,
        Sender = message.Sender
      };

      _store.Add(message);
    }

  }
}
