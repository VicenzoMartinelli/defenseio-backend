using DefenseIO.Domain.Domains.Contracting.Entities.Solicitation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DefenseIO.Services.Contracting.Data.Mappings
{
  public class SolicitationEvaluationMap : IEntityTypeConfiguration<SolicitationEvaluation>
  {
    public void Configure(EntityTypeBuilder<SolicitationEvaluation> builder)
    {
      builder.ToTable(nameof(SolicitationEvaluation));

      builder
        .HasKey(x => x.Id);

      builder
        .Property(x => x.ClientId).IsRequired();
      builder
        .Property(x => x.ProviderId).IsRequired();
      builder
        .Property(x => x.EfficiencyGrade).IsRequired();
      builder
        .Property(x => x.ExperienceGrade).IsRequired();
      builder
        .Property(x => x.SpeedGrade).IsRequired();
      builder
        .Property(x => x.EvaluationDate).IsRequired();
      builder
        .Property(x => x.Comment).HasMaxLength(1000);

      builder
        .HasOne(x => x.Solicitation)
        .WithOne(x => x.Evaluation);
    }
  }
}
