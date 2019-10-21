using DefenseIO.Domain.Domains.Users;
using DefenseIO.Domain.Domains.Users.Interfaces;
using DefenseIO.Infra.Shared.Interfaces;
using DefenseIO.Services.Identity.Data.Contexts;

namespace DefenseIO.Services.Identity.Data.Repositories
{
  public class ProviderUserRepository : AbstractRepository<AuthContext, ProviderUser>, IProviderUserRepository
  {
    public ProviderUserRepository(AuthContext context) : base(context)
    {

    }
  }
}
