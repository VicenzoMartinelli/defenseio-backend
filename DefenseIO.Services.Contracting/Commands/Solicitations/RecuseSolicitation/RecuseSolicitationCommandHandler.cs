using AutoMapper;
using DefenseIO.Domain.Domains.Contracting.Entities.Solicitation;
using DefenseIO.Domain.Domains.Contracting.Interfaces;
using DefenseIO.Infra.Shared.Extensions;
using DefenseIO.Infra.Shared.Messages;
using DefenseIO.Infra.Shared.Notifications;
using DefenseIO.Services.Contracting.Commands.Solicitations.Create;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DefenseIO.Services.Contracting.Commands.Solicitations
{
  public class RecuseSolicitationCommandHandler : IRequestHandler<RecuseSolicitationCommand, bool>
  {
    private readonly IMapper _mapper;
    private readonly NotificationContext _notificationContext;
    private readonly IAttendedModalityRepository _attendedModalityRepository;
    private readonly ISolicitationRepository _solicitationRepository;

    public RecuseSolicitationCommandHandler(
      IMapper mapper,
      NotificationContext notificationContext,
      IAttendedModalityRepository attendedModalityRepository,
      ISolicitationRepository solicitationRepository)
    {
      _mapper = mapper;
      _notificationContext = notificationContext;
      _attendedModalityRepository = attendedModalityRepository;
      _solicitationRepository = solicitationRepository;
    }

    public async Task<bool> Handle(RecuseSolicitationCommand request, CancellationToken cancellationToken)
    {
      var solicitation = await _solicitationRepository.FindById(request.Id);

      if (solicitation == null)
      {
        _notificationContext.BadRequest(nameof(Messages.ObjectNotExists), Messages.ObjectNotExists.FormatValues("Solicitação"));
        return false;
      }

      solicitation.Status = SolicitationStatus.Recused;

      await _solicitationRepository.Update(solicitation);

      return true;
    }
  }
}
