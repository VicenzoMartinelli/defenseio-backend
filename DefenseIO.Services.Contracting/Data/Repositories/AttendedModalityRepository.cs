using DefenseIO.Domain.Domains.Contracting.Entities;
using DefenseIO.Domain.Domains.Contracting.Interfaces;
using DefenseIO.Infra.Shared.Interfaces;
using DefenseIO.Services.Contracting.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace DefenseIO.Services.Contracting.Data.Repositories
{
  public class AttendedModalityRepository : AbstractRepository<ContractingContext, AttendedModality>, IAttendedModalityRepository
  {
    public AttendedModalityRepository(ContractingContext context) : base(context)
    {
    }
    public override async Task<AttendedModality> FindById(Guid id)
    {
      return await DbSet.Include(x => x.Modality).SingleOrDefaultAsync(x => x.Id == id);
    }
  }
}
