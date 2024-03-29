﻿using DefenseIO.Domain.Domains.Users;
using DefenseIO.Domain.Domains.Users.Interfaces;
using DefenseIO.Infra.ApiConfig;
using DefenseIO.Infra.ApiConfig.Filters;
using DefenseIO.Infra.ApiConfig.InputValidate;
using DefenseIO.Infra.DistributedCommunication.Commands;
using DefenseIO.Infra.Shared.Messages;
using DefenseIO.Services.Identity.Data.Contexts;
using DefenseIO.Services.Identity.Data.Repositories;
using DefenseIO.Services.Identity.Services;
using FluentValidation.AspNetCore;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DefenseIO.Services.Identity
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDefenseIOServiceConfig<AuthContext>(Configuration, () =>
      {
        services
          .AddIdentity<User, IdentityRole<Guid>>()
          .AddEntityFrameworkStores<AuthContext>()
          .AddDefaultTokenProviders()
          .AddErrorDescriber<DefenseErrorDescriber>();

        services.Configure<IdentityOptions>(options =>
        {
          options.Password.RequireDigit = false;
          options.Password.RequiredLength = 6;
          options.Password.RequireLowercase = false;
          options.Password.RequireNonAlphanumeric = false;
          options.Password.RequireUppercase = false;
          options.Lockout.MaxFailedAccessAttempts = 10;
          options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromHours(2);

          options.User.RequireUniqueEmail = true;

          options.Tokens.PasswordResetTokenProvider = TokenOptions.DefaultPhoneProvider;
          options.Tokens.EmailConfirmationTokenProvider = TokenOptions.DefaultPhoneProvider;
        });

        services.Configure<DataProtectionTokenProviderOptions>(options => options.TokenLifespan = TimeSpan.FromHours(1));

        services.AddMediatR(typeof(Startup).Assembly);

        services.AddScoped<IClientUserRepository, ClientUserRepository>();
        services.AddScoped<IProviderUserRepository, ProviderUserRepository>();
        services.AddScoped<AuthenticationService>();

        services.AddScoped<SyncFluentValidationFilter>();

        services.AddTransient<IValidatorInterceptor, FluentValidationInterceptor>();

        services.Configure<ApiBehaviorOptions>(options =>
        {
          options.SuppressModelStateInvalidFilter = true;
        });

        services.AddMassTransit(x =>
        {
          x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
          {
            var baseUri = $"rabbitmq://{Configuration["RabbitMQHost"]}";

            var host = cfg.Host(new Uri(baseUri), hostConfig =>
            {
              hostConfig.Username("guest");
              hostConfig.Password("guest");
            });

            EndpointConvention.Map<UserCreatedEvent>(new Uri($"{baseUri}/update_provider"));
          }));
        });
      });
    }

    public void Configure(IApplicationBuilder app)
    {
      app.UseDefaultDefenseIOPipeline(Configuration);
    }
  }
}
