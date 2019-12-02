using System;

namespace DefenseIO.Domain.Domains.Chatting
{
  public class ChatMessage
  {
    public Guid Id { get; private set; }
    public Guid ProviderId { get; set; }
    public Guid ClientId { get; set; }
    public DateTime SendedAt { get; private set; }
    public bool IsProviderSend { get; set; }
    public bool IsAttachment { get; set; }
    public string Content { get; set; }
    public string SenderName { get; set; }

    public ChatMessage()
    {
      Id = Guid.NewGuid();
      SendedAt = DateTime.Now;
    }
  }
}
