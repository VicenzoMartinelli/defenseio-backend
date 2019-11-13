using DefenseIO.Domain.Domains.Users;
using DefenseIO.Domain.Domains.Users.Interfaces;
using DefenseIO.Infra.Shared.Interfaces;
using DefenseIO.Services.Contracting.Data.Contexts;

namespace DefenseIO.Services.Contracting.Data.Repositories
{
  public class ProviderUserRepository : AbstractRepository<ContractingContext, ProviderUser>, IProviderUserRepository
  {
    public ProviderUserRepository(ContractingContext context) : base(context)
    {
    }
  }
}
