using DefenseIO.Domain.Domains.Geographic.Services;
using DefenseIO.Domain.Domains.Users;
using System;

namespace DefenseIO.Domain.Domains.Contracting.Entities.Solicitation
{
  public class Solicitation
  {
    public Guid Id { get; set; }
    public SolicitationStatus Status { get; set; }
    public ModalityType ModalityType { get; set; }
    public DateTime SolicitationDate { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime? EndDateTime { get; set; }
    public TimeSpan? TurnStart { get; set; }
    public TimeSpan? TurnOver { get; set; }
    public Location Location { get; set; }
    public string Remark { get; set; }
    public int? NumberOfEmployeers { get; set; }
    public double? KiloMeters { get; set; }
    public double FinalCost { get; set; }

    public AttendedModality AttendedModality { get; set; }
    public SolicitationEvaluation Evaluation { get; set; }

    public Guid ProviderId { get; set; }
    public Guid ClientId { get; set; }
    public Guid AttendedModalityId { get; set; }

    public Solicitation RecalculateCost()
    {
      var days = EndDateTime.Value - StartDateTime;

      switch (AttendedModality.Method)
      {
        case BilingMethod.Hour:
          var hoursPerday = TurnOver.Value - TurnStart.Value;

          FinalCost = Math.Ceiling(days.TotalDays * hoursPerday.TotalHours * AttendedModality.BasicValue);
          break;
        case BilingMethod.Period:
          FinalCost = Math.Ceiling(days.TotalDays * AttendedModality.BasicValue);
          break;
        case BilingMethod.KiloMeter:
          FinalCost = Math.Ceiling(AttendedModality.BasicValue * new DistanceService().GetDistanceBetweenTwoPointsInKms(new GeoPoint(Location.Latitude, Location.Longitude), null));
          break;
        case BilingMethod.Fixed:
          FinalCost = Math.Ceiling(AttendedModality.BasicValue);
          break;

        default:
          break;
      }
      return this;
    }
  }
}
