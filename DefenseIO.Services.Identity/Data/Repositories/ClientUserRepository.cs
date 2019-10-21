using DefenseIO.Domain.Domains.Users;
using DefenseIO.Domain.Domains.Users.Interfaces;
using DefenseIO.Infra.Shared.Interfaces;
using DefenseIO.Services.Identity.Data.Contexts;

namespace DefenseIO.Services.Identity.Data.Repositories
{
  public class ClientUserRepository : AbstractRepository<AuthContext, ClientUser>, IClientUserRepository
  {
    public ClientUserRepository(AuthContext context) : base(context)
    {

    }
  }
}
