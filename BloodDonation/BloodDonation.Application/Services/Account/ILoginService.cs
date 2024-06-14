using BloodDonation.Application.Models.InputModels.Account;
using BloodDonation.Application.Models.ViewModels.Account;

namespace BloodDonation.Application.Services.Account;
public interface ILoginService
{
    Task<LoginViewModel> Login(LoginInputModel model);
}
