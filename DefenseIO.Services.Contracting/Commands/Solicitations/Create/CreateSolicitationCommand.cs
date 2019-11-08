using DefenseIO.Infra.Shared.MediatR;
using System;

namespace DefenseIO.Services.Contracting.Commands.Solicitations.Create
{
  public class CreateSolicitationCommand : Command
  {
    // BASIC DATA
    public Guid Id { get; private set; }
    public Guid ClientId { get; private set; }
    public DateTime SolicitationDate { get; private set; }
    public Guid ProviderId { get; set; }
    public Guid AttendedModalityId { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime? EndDateTime { get; set; }
    public TimeSpan? TurnStart { get; set; }
    public TimeSpan? TurnOver { get; set; }
    public double? KiloMeters { get; set; }
    public int? NumberOfEmployeers { get; set; }
    public double FinalCost { get; set; }
    public string Remark { get; set; }

    // ADDRESS OF SOLICITATION
    public double Longitude { get; set; }
    public double Latitude { get; set; }
    public string Cep { get; set; }
    public string Address { get; set; }
    public string AddressNumber { get; set; }
    public string Complement { get; set; }
    public string Burgh { get; set; }
    public Guid CityId { get; set; }

    public CreateSolicitationCommand()
    {
      Id = Guid.NewGuid();
      SolicitationDate = DateTime.Now;
    }

    public CreateSolicitationCommand ByClient(Guid clientId)
    {
      ClientId = clientId;
      return this;
    }
  }
}
