using BloodDonation.Application.Models.InputModels.User;
using BloodDonation.Application.Models.ViewModels.User;

namespace BloodDonation.Application.Services.User;
public interface IUserService
{
    Task<UserCreatedViewModel> AddAsync(UserInputModel model);
}
