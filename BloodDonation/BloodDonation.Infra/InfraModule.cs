using BloodDonation.Infra.Persistence;
using BloodDonation.Infra.Persistence.UnityOfWork;
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
            .AddUnityOfWork();
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
}
