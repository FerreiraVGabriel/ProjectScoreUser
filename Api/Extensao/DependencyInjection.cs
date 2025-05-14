using Infra.Interface;
using Infra.Repository;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Interface;
using Service.Service;

namespace Api.Extensao
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            //SERVICES
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IScoreService, ScoreService>();

            //REPOSITORIES
            services.AddScoped<IClienteRepository, ClienteRepository>();

            return services;
        }
    }
}
