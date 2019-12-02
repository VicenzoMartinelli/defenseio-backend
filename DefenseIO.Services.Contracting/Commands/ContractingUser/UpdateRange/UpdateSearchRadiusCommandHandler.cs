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
  public class UpdateSearchRadiusCommandHandler : IRequestHandler<UpdateSearchRadiusCommand, bool>
  {
    private readonly NotificationContext _notificationContext;
    private readonly IContractingUserRepository _contractingUserRepository;
    public UpdateSearchRadiusCommandHandler(
      NotificationContext notificationContext,
      IContractingUserRepository contractingUserRepository)
    {
      _notificationContext = notificationContext;
      _contractingUserRepository = contractingUserRepository;
    }

    public async Task<bool> Handle(UpdateSearchRadiusCommand request, CancellationToken cancellationToken)
    {
      var user = await _contractingUserRepository.FindById(request.UserId);

      if (user == null)
      {
        _notificationContext.BadRequest(nameof(Messages.ObjectNotExists), Messages.ObjectNotExists.FormatValues("Usuário"));
        return false;
      }

      user.KiloMetersSearchRadius = request.KiloMetersSearchRadius;

      await _contractingUserRepository.Update(user);

      return true;
    }
  }
}
