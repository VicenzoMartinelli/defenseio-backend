using DefenseIO.Domain.Domains.Contracting.Entities.Solicitation;
using DefenseIO.Domain.Domains.Contracting.Interfaces;
using DefenseIO.Infra.Shared.Interfaces;
using DefenseIO.Services.Contracting.Data.Contexts;

namespace DefenseIO.Services.Contracting.Data.Repositories
{
  public class SolicitationRepository : AbstractRepository<ContractingContext, Solicitation>, ISolicitationRepository
  {
    public SolicitationRepository(ContractingContext context) : base(context)
    {
    }
  }
}
