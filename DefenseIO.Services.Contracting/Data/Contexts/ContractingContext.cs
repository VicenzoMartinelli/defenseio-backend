using DefenseIO.Domain.Domains.Contracting.Entities;
using DefenseIO.Domain.Domains.Contracting.Entities.Solicitation;
using DefenseIO.Services.Contracting.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace DefenseIO.Services.Contracting.Data.Contexts
{
  public class ContractingContext : DbContext
  {
    public DbSet<Modality> Modalities { get; set; }
    public DbSet<AttendedModality> AttendedModalities { get; set; }
    public DbSet<Solicitation> Solicitations { get; set; }
    public DbSet<SolicitationEvaluation> SolicitationEvaluations { get; set; }

    public ContractingContext(DbContextOptions<ContractingContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.ApplyConfigurationsFromAssembly(typeof(AttendedModalityMap).Assembly);
    }
  }
}
