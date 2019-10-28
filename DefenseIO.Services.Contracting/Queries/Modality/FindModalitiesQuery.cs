using DefenseIO.Domain.Domains.Contracting.ViewModels;
using DefenseIO.Infra.Shared.MediatR;
using System.Collections.Generic;

namespace DefenseIO.Services.Contracting.Queries.Modality
{
  public class FindModalitiesQuery : Query<IEnumerable<ModalityViewModel>>
  {
  }
}
