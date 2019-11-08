using AutoMapper;
using DefenseIO.Domain.Domains.Contracting.Interfaces;
using DefenseIO.Domain.Domains.Contracting.ViewModels;
using DefenseIO.Infra.Shared.Extensions;
using DefenseIO.Infra.Shared.Messages;
using DefenseIO.Infra.Shared.Notifications;
using DefenseIO.Infra.Shared.ViewModels;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DefenseIO.Services.Contracting.Commands.AttendedModality
{
  public class UpdateAttendedModalityCommandHandler : IRequestHandler<UpdateAttendedModalityCommand, CommandResult<AttendedModalityViewModel>>
  {
    private readonly IMapper _mapper;
    private readonly NotificationContext _notificationContext;
    private readonly IAttendedModalityRepository _attendedModalityRepository;
    private readonly IModalityRepository _modalityRepository;

    public UpdateAttendedModalityCommandHandler(
      IMapper mapper,
      NotificationContext notificationContext,
      IAttendedModalityRepository attendedModalityRepository,
      IModalityRepository modalityRepository)
    {
      _mapper = mapper;
      _notificationContext = notificationContext;
      _attendedModalityRepository = attendedModalityRepository;
      _modalityRepository = modalityRepository;
    }

    public async Task<CommandResult<AttendedModalityViewModel>> Handle(UpdateAttendedModalityCommand request, CancellationToken cancellationToken)
    {
      var result = new CommandResult<AttendedModalityViewModel>();

      if (!await _modalityRepository.Exists(x => x.Id == request.ModalityId))
      {
        _notificationContext.BadRequest(nameof(Messages.ObjectNotExists), Messages.ObjectNotExists.FormatValues("Modalidade"));
        return result.ReturningFailed();
      }

      var attendedModality = await _attendedModalityRepository.FindById(request.Id);

      attendedModality.BasicValue = request.BasicValue;
      attendedModality.Method = request.Method;
      attendedModality.ModalityId = request.ModalityId;
      attendedModality.MultiplyByEmployeesNumber = request.MultiplyByEmployeesNumber;

      await _attendedModalityRepository.Update(attendedModality);

      return result.ReturningSuccess(_mapper.Map<AttendedModalityViewModel>(attendedModality));
    }
  }
}
