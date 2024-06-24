using BloodDonation.Application.Models.InputModels.Donation;
using BloodDonation.Core.Exceptions;
using BloodDonation.Infra.Persistence.UnityOfWork;

namespace BloodDonation.Application.Services.Donation;
public class DonationService(IUnityOfWork unityOfWork) : IDonationService
{
    private readonly IUnityOfWork _unityOfWork = unityOfWork;

    public Task<Guid> Register(DonationInputModel model)
    {

        ///Menor de idade não pode doar, mas pode ter cadastro.
        ///Mulheres só podem doar de 90 em 90 dias.(PLUS)
        ///Homens só podem doar de 60 em 60 dias. (PLUS)

        ValidateModel(model);

        return default;
    }

    private static void ValidateModel(DonationInputModel model)
    {
        var validator = new DonationValidation();
        var result = validator.Validate(model);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
            throw new ValidationErrorsException(errorMessages);
        }
    }
}
