using DefenseIO.Domain.Domains.Chatting;
using DefenseIO.Domain.Domains.Chatting.Interfaces;
using DefenseIO.Infra.Shared.Interfaces;
using DefenseIO.Services.Chat.Data.Contexts;

namespace DefenseIO.Services.Chat.Data.Repositories
{
  public class ChatMessageRepository : AbstractRepository<ChatContext, ChatMessage>, IChatMessageRepository
  {
    public ChatMessageRepository(ChatContext context) : base(context)
    {
    }
  }
}
