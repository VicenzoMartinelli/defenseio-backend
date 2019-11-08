using DefenseIO.Domain.Domains.Contracting.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DefenseIO.Services.Contracting.Commands.AttendedModality
{
  public class DeleteAttendedModalityCommandHandler : IRequestHandler<DeleteAttendedModalityCommand, bool>
  {
    private readonly IAttendedModalityRepository _attendedModalityRepository;

    public DeleteAttendedModalityCommandHandler(IAttendedModalityRepository attendedModalityRepository)
    {
      _attendedModalityRepository = attendedModalityRepository;
    }

    public async Task<bool> Handle(DeleteAttendedModalityCommand request, CancellationToken cancellationToken)
    {
      var attendedModality = await _attendedModalityRepository.FindById(request.Id);

      await _attendedModalityRepository.Remove(attendedModality);

      return true;
    }
  }
}
