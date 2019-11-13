using DefenseIO.Domain.Domains.Contracting.Entities;
using DefenseIO.Domain.Domains.Contracting.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace DefenseIO.Services.Contracting.Queries.AttendedModalities
{
  public class FindAttendedModalitiesByTypeQuery : IRequest<IEnumerable<AttendedModalityProviderViewModel>>
  {
    public ModalityType Key { get; set; }
  }
}
