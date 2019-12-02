using DefenseIO.Infra.Shared.MediatR;
using System;

namespace DefenseIO.Services.Contracting.Commands.Solicitations.Create
{
  public class FinishSolicitationCommand : Command
  {
    public Guid Id { get; private set; }
    public double? SpeedGrade { get; set; }
    public double? EfficiencyGrade { get; set; }
    public double? ExperienceGrade { get; set; }
    public string Comment { get; set; }

    public FinishSolicitationCommand SetId(Guid id)
    {
      Id = id;

      return this;
    }
  }
}
