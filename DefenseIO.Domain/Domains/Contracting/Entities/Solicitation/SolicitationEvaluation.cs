using System;

namespace DefenseIO.Domain.Domains.Contracting.Entities.Solicitation
{
  public class SolicitationEvaluation
  {
    public Guid Id { get; set; }
    public DateTime EvaluationDate { get; set; }
    public double SpeedGrade { get; set; }
    public double EfficiencyGrade { get; set; }
    public double ExperienceGrade { get; set; }
    public string Comment { get; set; }
    public Solicitation Solicitation { get; set; }

    public Guid SolicitationId { get; set; }
    public Guid ProviderId { get; set; }
    public Guid ClientId { get; set; }
  }
}
