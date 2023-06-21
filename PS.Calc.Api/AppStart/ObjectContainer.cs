using Microsoft.AspNetCore.Authorization;
using PS.Calc.Api.Auth;
using PS.Calc.Api.AutoMapperProfiles;
using PS.Calc.Api.Services.Definitions;
using PS.Calc.Api.Services.Interfaces;
using PS.Calc.Data;
using PS.Calc.Data.Definitions;
using PS.Calc.Logging;

namespace PS.Calc.Api.AppStart
{
    public static class ObjectContainer
    {
        public static IServiceCollection AddApplicationObjects(this IServiceCollection services)
        {
            services.AddServiceDependencies();
            services.AddRepository();
            services.AddOthes();
            return services;
        }

        private static void AddServiceDependencies(this IServiceCollection services)
        {
            services.AddScoped<ISampleService, SampleService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAuthorizationHandler, AppSpecificHandler>();
            services.AddScoped<IAuthorizationHandler, WindowsAuthNHandler>();
        }
        private static void AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IRepository, AppRepository>();
        }
        private static void AddOthes(this IServiceCollection services)
        {
            services.AddScoped<LogAttribute>();
            services.AddAutoMapper(typeof(EmployeeAutoMapperProfile));
        }
    }
}
