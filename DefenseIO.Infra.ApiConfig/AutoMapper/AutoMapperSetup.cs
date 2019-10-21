using AutoMapper;
using DefenseIO.Infra.Shared.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace DefenseIO.Infra.ApiConfig.AutoMapper
{
  public static class AutoMapperSetup
  {
    public static IServiceCollection AddAutoMapperSetup(this IServiceCollection services)
    {
      MapperConfiguration mappingConfig = new MapperConfiguration(mc =>
      {
        mc.CreateMap<byte, bool>().ConvertUsing(s => s.AsBool());

      });

      IMapper mapper = mappingConfig.CreateMapper();
      services.AddSingleton(mapper);

      return services;
    }
  }
}
