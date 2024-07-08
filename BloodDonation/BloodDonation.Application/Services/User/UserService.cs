using BloodDonation.Application.Models.InputModels.User;
using BloodDonation.Application.Models.ViewModels.User;
using BloodDonation.Application.Services.Authentication;
using BloodDonation.Core.Exceptions;
using BloodDonation.Infra.Persistence.UnityOfWork;

namespace BloodDonation.Application.Services.User;
public class UserService : IUserService
{
    private readonly IUnityOfWork _unityOfWork;
    private readonly IAuthService _authService;
    public UserService(IUnityOfWork unityOfWork, IAuthService authService)
    {
        _unityOfWork = unityOfWork;
        _authService = authService;
    }
    public async Task<UserCreatedViewModel> AddAsync(UserInputModel model)
    {
        Validate(model);

        string passwordHash = _authService.ComputeSha256Hash(model.Password);

        var user = model.ToEntity(passwordHash);

        await ValidateEmailAlreadyIntegrated(model.Email, user.Id);

        await _unityOfWork.Users.AddAsync(user);
        await _unityOfWork.CompleteAsync();

        var token = _authService.GenerateJwtToken(user);

        return new UserCreatedViewModel(token);
    }

    private static void Validate(UserInputModel model)
    {
        var validator = new UserValidation();
        var result = validator.Validate(model);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
            throw new ValidationErrorsException(errorMessages);
        }
    }

    private async Task ValidateEmailAlreadyIntegrated(string email, Guid id)
    {
        bool existUserWithEmail = await _unityOfWork.Users.ExistUserWithEmail(email, id);
        if (existUserWithEmail)
        {
            throw new ValidationErrorsException("E-mail já cadastrado");
        }
    }
}
