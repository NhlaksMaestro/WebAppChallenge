using System;
using Microsoft.Extensions.DependencyInjection;
using WebAppChallenge.Domain;
using WebChallenge.Contracts.Domain;
using WebChallenge.Contracts.Repository;
using WebChallenge.Repository;

namespace WebAppChallenge.Factory
{
    public static class Factory
    {
        public static void AddDependencies(IServiceCollection services)
        {
            services.AddDbContext<EmployeeDBContext>();
            AddRepositoriesDependencies(services);
            AddDomainDependencies(services);
        }

        //add references by layer start with repository
        private static void AddRepositoriesDependencies(IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository> ();
        }
        private static void AddDomainDependencies(IServiceCollection services)
        {
            services.AddScoped<ISettings, Settings>();
        }

    }
}

