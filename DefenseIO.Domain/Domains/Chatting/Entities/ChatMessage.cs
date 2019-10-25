using System;

namespace DefenseIO.Domain.Domains.Chatting
{
  public class ChatMessage
  {
    public Guid Id { get; set; }
    public Guid ProviderId { get; set; }
    public Guid ClientId { get; set; }
    public bool IsProviderSend { get; set; }
    public bool IsAttachment { get; set; }
    public string Content { get; set; }
  }
}
