using BloodDonation.Application.Services.Account;
using BloodDonation.Application.Services.Address;
using BloodDonation.Application.Services.Authentication;
using BloodDonation.Application.Services.User;
using Microsoft.Extensions.DependencyInjection;

namespace BloodDonation.Application;
public static class ApplicationModule
{
    public static void AddApplicationModule(this IServiceCollection services)
    {
        services.AddServices();
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        return services
            .AddScoped<IUserService, UserService>()
            .AddScoped<IAuthService, AuthService>()
            .AddScoped<ILoginService, LoginService>()
            .AddScoped<IAddressService, AddressService>();
    }
}
