using Microsoft.EntityFrameworkCore;

namespace DefenseIO.Services.Chat.Data.Contexts
{
  public class ChatContext : DbContext
  {

    public ChatContext(DbContextOptions<ChatContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
  }
}
