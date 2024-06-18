using BloodDonation.Core.Repositories;
using BloodDonation.Infra.Persistence;
using BloodDonation.Infra.Persistence.Repositories;
using BloodDonation.Infra.Persistence.UnityOfWork;
using BloodDonation.Infra.ViaCep;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BloodDonation.Infra;
public static class InfraModule
{
    public static void AddInfraModule(this IServiceCollection services)
    {
        var connectionString = Environment.GetEnvironmentVariable("CS_MYSQL_LOCALHOST_BLOOD_DONATION");

        services
            .AddDb(connectionString)
            .AddUnityOfWork()
            .AddRepositories()
            .AddExternalClients();
    }

    private static IServiceCollection AddDb(this IServiceCollection services, string? connectionString)
    {
        services.AddDbContext<BloodDonationDbContext>(options =>
        {
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        });

        return services;
    }

    private static IServiceCollection AddUnityOfWork(this IServiceCollection services)
    {
        return services.AddScoped<IUnityOfWork, UnityOfWork>();
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services
            .AddScoped<IUserRepository, UserRepository>();
    }

    public static IServiceCollection AddExternalClients(this IServiceCollection services)
    {
        return services
            .AddScoped<IViaCepClient, ViaCepClient>();
    }
}
