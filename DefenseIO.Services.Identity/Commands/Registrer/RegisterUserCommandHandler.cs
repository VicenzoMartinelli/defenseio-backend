using DefenseIO.Domain.Domains.Users;
using DefenseIO.Domain.Domains.Users.Interfaces;
using DefenseIO.Domain.Domains.Users.ViewModels;
using DefenseIO.Infra.Shared.Extensions;
using DefenseIO.Infra.Shared.Notifications;
using DefenseIO.Infra.Shared.ViewModels;
using DefenseIO.Services.Identity.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace DefenseIO.Services.Identity.Commands.Registrer
{
  public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, CommandResult<TokenViewModel>>
  {
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IClientUserRepository _clientRepository;
    private readonly IProviderUserRepository _providerRepository;
    private readonly NotificationContext _notificationContext;
    private readonly AuthenticationService _service;

    public RegisterUserCommandHandler(
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

    public async Task<CommandResult<TokenViewModel>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
      var exit = new CommandResult<TokenViewModel>();

      var user = new User()
      {
        Email = request.Email,
        Name = request.Name,
        Type = request.Type,
        Active = true,
        DocumentIdentifier = request.DocumentIdentifier,
        PhoneNumber = request.PhoneNumber,
        PrimaryLocation = new Location()
        {
          Address = request.Address,
          AddressNumber = request.AddressNumber,
          Burgh = request.Burgh,
          Cep = request.Cep,
          Complement = request.Complement,
          CityId = request.CityId,
          Latitude = request.Latitude,
          Longitude = request.Longitude
        }
      };

      var result = await _userManager.CreateAsync(user, request.Password);

      if (!result.Succeeded)
      {
        _notificationContext.PushNotifications(result.Errors.ExtractNotificationsFromIdentityErrors());

        return exit;
      }

      if (request.Type == UserType.Client)
      {
        await _clientRepository.Add(user.Client = new ClientUser()
        {
          BirthDate = request.BirthDate,
          KiloMetersSearchRadius = request.KiloMetersSearchRadius,
          Rg = request.Rg,
          UserId = user.Id
        });
      }
      else
      {
        await _providerRepository.Add(user.Provider = new ProviderUser()
        {
          BrazilianInscricaoEstadual = request.BrazilianInscricaoEstadual,
          LicenseValidity = request.LicenseValidity,
          UserId = user.Id
        });
      }

      return exit.ReturningSuccess(await _service.GenerateToken(user));
    }
  }
}
