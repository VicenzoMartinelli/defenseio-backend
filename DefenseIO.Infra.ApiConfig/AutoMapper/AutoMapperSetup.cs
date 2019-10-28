using AutoMapper;
using DefenseIO.Domain.Domains.Contracting.Entities;
using DefenseIO.Domain.Domains.Contracting.ViewModels;
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

        mc.CreateMap<Modality, ModalityViewModel>();

        mc.CreateMap<AttendedModality, AttendedModalityViewModel>()
        .ForMember((x) => x.Modality, (src) => src.MapFrom((p, viewModel, d, r) => r.Mapper.Map<ModalityViewModel>(p.Modality)));
      });

      IMapper mapper = mappingConfig.CreateMapper();
      services.AddSingleton(mapper);

      return services;
    }
  }
}
