using DefenseIO.Domain.Domains.Users;
using DefenseIO.Domain.Domains.Users.Interfaces;
using DefenseIO.Domain.Domains.Users.ViewModels;
using DefenseIO.Infra.Shared.Messages;
using DefenseIO.Infra.Shared.Notifications;
using DefenseIO.Infra.Shared.ViewModels;
using DefenseIO.Services.Identity.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace DefenseIO.Services.Identity.Commands.Registrer
{
  public class LoginCommandHandler : IRequestHandler<LoginCommand, CommandResult<TokenViewModel>>
  {
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IClientUserRepository _clientRepository;
    private readonly IProviderUserRepository _providerRepository;
    private readonly NotificationContext _notificationContext;
    private readonly AuthenticationService _service;

    public LoginCommandHandler(
      UserManager<User> userManager,
      SignInManager<User> signInManager,
      IClientUserRepository clientRepository,
      IProviderUserRepository providerRepository,
      NotificationContext notificationContext,
      AuthenticationService service)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _clientRepository = clientRepository;
      _providerRepository = providerRepository;
      _notificationContext = notificationContext;
      _service = service;
    }

    public async Task<CommandResult<TokenViewModel>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
      var exit = new CommandResult<TokenViewModel>();

      if (cancellationToken.IsCancellationRequested)
      {
        return exit;
      }

      var user = await _userManager.FindByNameAsync(request.DocumentIdentifier);

      if (user == null)
      {
        _notificationContext.BadRequest(nameof(Messages.InvalidCredentials), Messages.InvalidCredentials);

        return exit;
      }

      var result = await _signInManager.PasswordSignInAsync(user, request.Password, false, true);

      if (!result.Succeeded)
      {
        _notificationContext.BadRequest(nameof(Messages.InvalidCredentials), Messages.InvalidCredentials);

        return exit;
      }

      return exit.ReturningSuccess(await _service.GenerateToken(user));
    }
  }
}
