using DefenseIO.Domain.Domains.Contracting.Interfaces;
using DefenseIO.Services.Contracting.Queries.ContractingUser;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DefenseIO.Services.Contracting.Queries.Modality
{
  public class FindSearchRadiusByContractingUserQueryHandler : IRequestHandler<FindSearchRadiusByContractingUserQuery, long>
  {
    private readonly IContractingUserRepository _userRepository;

    public FindSearchRadiusByContractingUserQueryHandler(
      IContractingUserRepository userRepository)
    {
      _userRepository = userRepository;
    }

    public async Task<long> Handle(FindSearchRadiusByContractingUserQuery request, CancellationToken cancellationToken)
    {
      var user = await _userRepository.FindById(request.UserId);

      return user.KiloMetersSearchRadius;
    }
  }
}
