using Microsoft.EntityFrameworkCore;

// Core
using MedicalPatients.Core.Interfaces;

// Infrastructure
using PatientHubApi.Infrastructure.Data;
using PatientHubApi.Infrastructure.Repositories;

namespace PatientHubApi.Infrastructure;

public static class DependencyInjection
{

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)

    {
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
            configuration.GetConnectionString("DefaultConnection")
        ));
        services.AddScoped<IPatientRepository, PatientRepository>();

        return services;
    }

}
