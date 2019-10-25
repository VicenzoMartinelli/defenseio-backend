using DefenseIO.Domain.Domains.Contracting.Entities.Solicitation;
using DefenseIO.Domain.Domains.Contracting.Interfaces;
using DefenseIO.Infra.Shared.Interfaces;
using DefenseIO.Services.Contracting.Data.Contexts;

namespace DefenseIO.Services.Contracting.Data.Repositories
{
  public class SolicitationEvaluationRepository : AbstractRepository<ContractingContext, SolicitationEvaluation>, ISolicitationEvaluationRepository
  {
    public SolicitationEvaluationRepository(ContractingContext context) : base(context)
    {
    }
  }
}
