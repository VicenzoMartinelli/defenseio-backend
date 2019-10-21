using DefenseIO.Infra.ApiConfig.Swagger.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;

namespace DefenseIO.Infra.ApiConfig.Swagger
{
  public static class SwaggerConfig
  {
    public static IServiceCollection AddCustomizedSwagger(this IServiceCollection services, IConfiguration configuration)
    {
      var serviceName = configuration.GetValue<string>("ServiceConfig:displayName");

      services.AddSwaggerGen(cfg =>
      {
        cfg.DocumentFilter<EnumDocumentFilter>();

        var contact = new Contact
        {
          Name = "DefenseIO",
          Email = "defenseio@gmail.com"
        };

        cfg.SwaggerDoc(
            "v1",
            new Info
            {
              Version = "v1",
              Title = $"DefenseIO | {serviceName}",
              Description = $"DefenseIO | {serviceName}",
              Contact = contact
            });

        cfg.AddSecurityDefinition(
            "Bearer",
            new ApiKeyScheme
            {
              In = "header",
              Description = "Copie 'Bearer ' + token'",
              Name = "Authorization",
              Type = "apiKey"
            });

        cfg.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
        {
            {"Bearer", new string[] { }},
        });
      });

      return services;
    }
  }
}
