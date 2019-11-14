using DefenseIO.Domain.Domains.Contracting.Entities;
using DefenseIO.Domain.Domains.Contracting.Interfaces;
using DefenseIO.Infra.Shared.Interfaces;
using DefenseIO.Services.Contracting.Data.Contexts;

namespace DefenseIO.Services.Contracting.Data.Repositories
{
  public class ContractingUserRepository : AbstractRepository<ContractingContext, ContractingUser>, IContractingUserRepository
  {
    public ContractingUserRepository(ContractingContext context) : base(context)
    {
    }
  }
}
