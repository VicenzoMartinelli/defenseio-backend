using MediatR;
using System;

namespace DefenseIO.Services.Contracting.Queries.ContractingUser
{
  public class FindSearchRadiusByContractingUserQuery : IRequest<long>
  {
    public Guid UserId { get; set; }

    public FindSearchRadiusByContractingUserQuery(Guid userId)
    {
      UserId = userId;
    }
  }
}
