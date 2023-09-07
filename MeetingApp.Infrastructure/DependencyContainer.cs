using MeetingApp.Application.Interfaces.Repositories;
using MeetingApp.Application.Utilities.AppSettings;
using MeetingApp.Infrastructure.Repositories;
using MeetingApp.Infrastructure.Repositories.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

            return services;
        }
    }
}