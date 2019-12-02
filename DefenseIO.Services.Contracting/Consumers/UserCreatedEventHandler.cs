using DefenseIO.Domain.Domains.Contracting.Entities;
using DefenseIO.Domain.Domains.Contracting.Interfaces;
using DefenseIO.Infra.DistributedCommunication.Commands;
using MassTransit;
using System.Threading.Tasks;

namespace DefenseIO.Services.Contracting.Consumers
{
  public class UserCreatedEventHandler : IConsumer<UserCreatedEvent>
  {
    private readonly IContractingUserRepository _repository;

    public UserCreatedEventHandler(IContractingUserRepository repo)
    {
      _repository = repo;
    }

    public async Task Consume(ConsumeContext<UserCreatedEvent> context)
    {
      await _repository.Add(new ContractingUser()
      {
        Id = context.Message.Id,
        BrazilianInscricaoEstadual = context.Message.BrazilianInscricaoEstadual,
        LicenseValidity = context.Message.LicenseValidity,
        Name = context.Message.Name,
        Email = context.Message.Email,
        PhoneNumber = context.Message.PhoneNumber,
        Address = context.Message.Address,
        AddressNumber = context.Message.AddressNumber,
        Cep = context.Message.Cep,
        CityId = context.Message.CityId,
        Burgh = context.Message.Burgh,
        Complement = context.Message.Complement,
        Latitude = context.Message.Latitude,
        Longitude = context.Message.Longitude,
        BirthDate = context.Message.BirthDate,
        DocumentIdentifier = context.Message.DocumentIdentifier,
        Rg = context.Message.Rg,
        Type = context.Message.Type,
        KiloMetersSearchRadius = context.Message.KiloMetersSearchRadius
      });

      await _repository.SaveChanges();
    }
  }
}
