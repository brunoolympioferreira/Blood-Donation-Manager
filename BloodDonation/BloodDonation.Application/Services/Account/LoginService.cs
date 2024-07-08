using BloodDonation.Application.Models.InputModels.Account;
using BloodDonation.Application.Models.ViewModels.Account;
using BloodDonation.Application.Services.Authentication;
using BloodDonation.Core.Exceptions;
using BloodDonation.Infra.Persistence.UnityOfWork;

namespace BloodDonation.Application.Services.Account;
internal class LoginService : ILoginService
{
    private readonly IUnityOfWork _uow;
    private readonly IAuthService _authService;
    public LoginService(IUnityOfWork uow, IAuthService authService)
    {
        _uow = uow;
        _authService = authService;
    }
    public async Task<LoginViewModel> Login(LoginInputModel model)
    {
        string passwordHash = _authService.ComputeSha256Hash(model.Password);

        Core.Entities.User user = await _uow.Users.GetUserByEmailAndPasswordAsync(model.Email, passwordHash) ??
            throw new ValidationErrorsException("Nome de usuário e/ou senha inválido");

        string token = _authService.GenerateJwtToken(user);

        return new LoginViewModel(token);
    }
}
