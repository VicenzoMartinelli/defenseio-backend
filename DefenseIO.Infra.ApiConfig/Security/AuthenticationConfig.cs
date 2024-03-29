﻿using DefenseIO.Domain.Domains.Users.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Threading.Tasks;

namespace DefenseIO.Infra.ApiConfig.Security
{
  public static class AuthenticationConfig
  {
    public static IServiceCollection AddAuthenticationSetup(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddScoped<ILoggedUserAcessor, LoggedUserAcessor>();

      var secSettings = configuration.GetSection("TokenValidationConfig");
      services.Configure<ValidationTokenConfig>(secSettings);
      var secObj = secSettings.Get<ValidationTokenConfig>();

      return services
      .AddAuthentication(x =>
      {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      }).AddJwtBearer(x =>
      {
        x.RequireHttpsMetadata = true;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secObj.Secret)),
          ValidateIssuer = true,
          ValidateAudience = false,
          ValidIssuer = secObj.Audience
        };
        x.Events = new JwtBearerEvents
        {
          OnMessageReceived = context =>
          {
            var accessToken = context.Request.Query["access_token"];

            var path = context.HttpContext.Request.Path;
            if (!string.IsNullOrEmpty(accessToken) &&
                (path.StartsWithSegments("/chat")))
            {
              context.Token = accessToken;
            }
            return Task.CompletedTask;
          }
        };
      }).Services;
    }
  }
}
