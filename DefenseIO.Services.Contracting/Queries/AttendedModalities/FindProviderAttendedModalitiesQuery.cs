using DefenseIO.Domain.Domains.Contracting.ViewModels;
using DefenseIO.Infra.Shared.MediatR;
using System;
using System.Collections.Generic;

namespace DefenseIO.Services.Contracting.Queries.Modality
{
  public class FindProviderAttendedModalitiesQuery : Query<IEnumerable<AttendedModalityViewModel>>
  {
    public Guid ProviderId { get; set; }
    public FindProviderAttendedModalitiesQuery(Guid providerId)
    {
      ProviderId = providerId;
    }
  }
}
