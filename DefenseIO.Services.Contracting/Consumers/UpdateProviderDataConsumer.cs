using DefenseIO.Domain.Domains.Users;
using DefenseIO.Domain.Domains.Users.Interfaces;
using DefenseIO.Infra.DistributedCommunication.Commands;
using MassTransit;
using System.Threading.Tasks;

namespace DefenseIO.Services.Contracting.Consumers
{
  public class UpdateProviderDataConsumer : IConsumer<UpdateProviderDataCommand>
  {
    private readonly IProviderUserRepository _providerUserRepository;

    public UpdateProviderDataConsumer(IProviderUserRepository providerUserRepository)
    {
      _providerUserRepository = providerUserRepository;
    }

    public async Task Consume(ConsumeContext<UpdateProviderDataCommand> context)
    {
      await _providerUserRepository.Add(new ProviderUser()
      {
        UserId = context.Message.Id,
        BrazilianInscricaoEstadual = context.Message.BrazilianInscricaoEstadual,
        LicenseValidity = context.Message.LicenseValidity,
        User = new User()
        {
          Name = context.Message.Name,
          Email = context.Message.Email,
          PhoneNumber = context.Message.PhoneNumber,
          PrimaryLocation = new Location()
          {
            Address = context.Message.Address,
            AddressNumber = context.Message.AddressNumber,
            Cep = context.Message.Cep,
            CityId = context.Message.CityId,
            Burgh = context.Message.Burgh,
            Complement = context.Message.Complement,
            Latitude = context.Message.Latitude,
            Longitude = context.Message.Longitude
          }
        }
      });

      await _providerUserRepository.SaveChanges();
    }
  }
}
