using DefenseIO.Domain.Domains.Chatting;
using DefenseIO.Services.Chat.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace DefenseIO.Services.Chat.Data.Contexts
{
  public class ChatContext : DbContext
  {
    public DbSet<ChatMessage> Messages { get; set; }

    public ChatContext(DbContextOptions<ChatContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfiguration(new ChatMessageMap());
    }
  }
}
