using DefenseIO.Infra.ApiConfig.AutoMapper;
using DefenseIO.Infra.ApiConfig.Database;
using DefenseIO.Infra.ApiConfig.Filters;
using DefenseIO.Infra.ApiConfig.Middleware;
using DefenseIO.Infra.ApiConfig.Security;
using DefenseIO.Infra.ApiConfig.ServiceDiscovery;
using DefenseIO.Infra.ApiConfig.Swagger;
using DefenseIO.Infra.Shared.Notifications;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using System;

namespace DefenseIO.Infra.ApiConfig
{
  public static class DefenseIOConfig
  {
    public static void AddDefenseIOServiceConfig<TDBContext>(
        this IServiceCollection services,
        IConfiguration configuration,
        Action customServicesInitializer = null
        ) where TDBContext : DbContext
    {

      services
        .AddScoped<NotificationContext>()
        .AddServiceDiscovery(configuration.GetServiceConfig())
        .AddAutoMapperSetup()
        .AddServiceDb<TDBContext>(configuration)
        .AddAuthenticationSetup(configuration)
        .AddCustomizedSwagger(configuration)
        .AddMvc((opt) =>
        {
          opt.Filters.Add(typeof(SyncFluentValidationFilter));
          opt.Filters.Add(typeof(RequestTransactionFilter<TDBContext>));
        })
          .AddFluentValidation()
          .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
          .AddJsonOptions(x =>
          {
            x.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
          });

      customServicesInitializer?.Invoke();
    }

    public static void UseDefaultDefenseIOPipeline(
      this IApplicationBuilder app,
      IConfiguration configuration,
      Action customMiddlewaresAdd = null)
    {
      app.UseGlobalErrorHandler();

      app.UseCors(c =>
      {
        c.AllowAnyHeader();
        c.AllowAnyMethod();
        c.AllowAnyOrigin();
      });

      app.UseAuthentication();

      customMiddlewaresAdd?.Invoke();

      app.UseMvc();

      app.UseDefaultSwagger(configuration);
    }
  }
}
