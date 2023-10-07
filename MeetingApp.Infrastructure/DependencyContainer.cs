using MeetingApp.Application.Interfaces.CacheService;
using MeetingApp.Application.Interfaces.LookupHelper;
using MeetingApp.Application.Interfaces.Repositories;
using MeetingApp.Application.Utilities.AppSettings;
using MeetingApp.Application.Utilities.Sieve;
using MeetingApp.Infrastructure.Cache;
using MeetingApp.Infrastructure.LookupHelper;
using MeetingApp.Infrastructure.Persistence.Context;
using MeetingApp.Infrastructure.Repositories;
using MeetingApp.Infrastructure.Repositories.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sieve.Models;
using StackExchange.Redis;

namespace MeetingApp.Infrastructure
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettingsSection = configuration.GetSection("MeetingAppSettings");
            //services.Configure<MeetingAppSettings>(appSettingsSection);

            #region Repositories
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IDegreeRepository, DegreeRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserOtpRepository, UserOtpRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IPackageRepository, PackageRepository>();

            #endregion

            ConfigurationOptions configurationOptions = new ConfigurationOptions()
            {
                EndPoints = { configuration.GetSection("MeetingAppSettings:RedisSettings:ServiceUrl").Value!.ToString() },
                AllowAdmin = true,
                ConnectTimeout = 60 * 1000,
                Password = configuration.GetSection("MeetingAppSettings:RedisSettings:Password").Value!.ToString(),
            };

            var multiplexer = ConnectionMultiplexer.Connect(configurationOptions);
            services.AddSingleton<IConnectionMultiplexer>(multiplexer);

            services.AddDistributedMemoryCache();

            services.AddScoped<ICacheService, CacheService>();

            services.AddScoped<ILookupHelper, LookupHelper.LookupHelper>();
            services.AddScoped(typeof(ILookupHelper), typeof(ResolverHelper));

            services.AddScoped<BaseApplicationSieveProcessor<DataFilterModel, FilterTerm, SortTerm>>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddDbContext<MeetingAppDbContext>(options =>
                        options.UseMySQL(configuration.GetConnectionString("ConnectionString")!));

            return services;

            return services;
        }
    }
}