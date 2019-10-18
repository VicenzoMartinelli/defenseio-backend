using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sponte.Erp.Legado.PortalPaciente.Infra.IoC;

namespace DefenseIO.Infra.ApiConfig.AutoMapper
{
  public static class AutoMapperSetup
  {
    private static object _initialized = false;

    public static void AddAutoMapperSetup(this IServiceCollection services)
    {
      lock (_initialized)
      {
        Mapper.Reset();

        var cfg = CreateMapper();

        Mapper.Initialize(cfg);

        services.AddAutoMapper(AddProfiles, typeof(Startup));

        _initialized = true;
      }
    }

    private static MapperConfigurationExpression CreateMapper()
    {
      var cfg = new MapperConfigurationExpression();

      cfg.CreateMap<byte, bool>().ConvertUsing(s => s.AsBool());
      cfg.AddProfiles();

      return cfg;
    }
  }
}
