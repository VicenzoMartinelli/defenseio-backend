using DefenseIO.Domain.Domains.Contracting.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;

namespace DefenseIO.Services.Contracting.Queries.ContractingUser
{
  public class FindCommentsByProviderQuery : IRequest<IEnumerable<ProviderCommentsViewModel>>
  {
    public Guid ProviderId { get; set; }

    public FindCommentsByProviderQuery(Guid userId)
    {
      ProviderId = userId;
    }
  }
}
