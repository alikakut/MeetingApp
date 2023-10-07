using System.Reflection;
using FluentValidation;
using Mapster;
using MapsterMapper;
using MediatR;
using MeetingApp.Application.Mapping;
using MeetingApp.Application.Utilities.AppSettings;
using MeetingApp.Application.Utilities.Authorization.Helper;
using MeetingApp.Application.Utilities.Authorization.Session;
using MeetingApp.Application.Utilities.Validator;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MeetingApp.Application
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettingsSection = configuration.GetSection("MeetingAppSettings");
            services.Configure<MeetingAppSettings>(appSettingsSection);

            #region Mapster Configuration
            var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
            typeAdapterConfig.Scan(Assembly.GetAssembly(typeof(EntityToCommandAdapter))!);
            var mapperConfig = new Mapper(typeAdapterConfig);
            services.AddSingleton<IMapper>(mapperConfig);
            #endregion

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(20);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddScoped<SessionManager>();
            services.AddScoped<TokenHelper>();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}
