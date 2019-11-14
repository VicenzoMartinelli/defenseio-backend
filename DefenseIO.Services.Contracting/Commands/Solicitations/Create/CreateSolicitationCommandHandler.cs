using AutoMapper;
using DefenseIO.Domain.Domains.Contracting.Entities.Solicitation;
using DefenseIO.Domain.Domains.Contracting.Interfaces;
using DefenseIO.Domain.Domains.Users;
using DefenseIO.Infra.Shared.Extensions;
using DefenseIO.Infra.Shared.Messages;
using DefenseIO.Infra.Shared.Notifications;
using DefenseIO.Services.Contracting.Commands.Solicitations.Create;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DefenseIO.Services.Contracting.Commands.Solicitations
{
  public class CreateSolicitationCommandHandler : IRequestHandler<CreateSolicitationCommand, bool>
  {
    private readonly IMapper _mapper;
    private readonly NotificationContext _notificationContext;
    private readonly IAttendedModalityRepository _attendedModalityRepository;
    private readonly ISolicitationRepository _solicitationRepository;

    public CreateSolicitationCommandHandler(
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

    public async Task<bool> Handle(CreateSolicitationCommand request, CancellationToken cancellationToken)
    {
      var attendedModality = await _attendedModalityRepository.FindById(request.AttendedModalityId);

      if (attendedModality == null)
      {
        _notificationContext.BadRequest(nameof(Messages.ObjectNotExists), Messages.ObjectNotExists.FormatValues("Modalidade"));
        return false;
      }

      var solicitation = new Solicitation()
      {
        Id = request.Id,
        AttendedModality = attendedModality,
        AttendedModalityId = attendedModality.Id,
        ClientId = request.ClientId,
        ModalityType = attendedModality.Modality.Key,
        NumberOfEmployeers = 1,
        KiloMeters = request.KiloMeters,
        ProviderId = attendedModality.ProviderUserId,
        Remark = request.Remark,
        SolicitationDate = request.SolicitationDate,
        EndDateTime = request.EndDateTime,
        StartDateTime = request.StartDateTime,
        Location = new Location()
        {
          Address = request.Address,
          AddressNumber = request.AddressNumber,
          Burgh = request.Burgh,
          Cep = request.Cep,
          CityId = request.CityId,
          Complement = request.Complement,
          Latitude = request.Latitude,
          Longitude = request.Longitude
        },
        Status = SolicitationStatus.Created,
        TurnStart = request.TurnStart,
        TurnOver = request.TurnOver,
      };

      await _solicitationRepository.Add(solicitation.RecalculateCost());

      return true;
    }
  }
}
