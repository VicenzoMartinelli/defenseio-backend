using Microsoft.EntityFrameworkCore;

namespace DefenseIO.Services.Contracting.Data.Contexts
{
  public class ContractingContext : DbContext
  {

    public ContractingContext(DbContextOptions<ContractingContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
  }
}
