// Application
using MedicalPatients.Application.Interfaces;
using PatientHubApi.Application.Services;

namespace PatientHubApi.Application;

public static class DependencyInjection
{

    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IPatientService, PatientService>();
        return services;
    }

}
