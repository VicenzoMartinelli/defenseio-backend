using DefenseIO.Domain.Domains.Chatting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DefenseIO.Services.Chat.Data.Mappings
{
  public class ChatMessageMap : IEntityTypeConfiguration<ChatMessage>
  {
    public void Configure(EntityTypeBuilder<ChatMessage> builder)
    {
      builder.ToTable(nameof(ChatMessage));

      builder
        .HasKey(x => x.Id);

      builder
        .Property(x => x.ProviderId).IsRequired();
      builder
        .Property(x => x.ClientId).IsRequired();

      builder
        .Property(x => x.Content);

      builder
        .Property(x => x.IsProviderSend);

      builder
        .Property(x => x.IsAttachment);
    }
  }
}
