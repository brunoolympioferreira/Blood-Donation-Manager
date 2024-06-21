using BloodDonation.Application.Models.InputModels.Donor;
using BloodDonation.Core.Exceptions;
using BloodDonation.Infra.Persistence.UnityOfWork;

namespace BloodDonation.Application.Services.Donor;
public class DonorService : IDonorService
{
    private readonly IUnityOfWork _unityOfWork;
    public DonorService(IUnityOfWork unityOfWork)
    {
        _unityOfWork = unityOfWork;
    }

    public Task<Guid> Create(DonorInputModel model)
    {
        ValidateModel(model);

        return default;
    }

    private static void ValidateModel(DonorInputModel model)
    {
        var validator = new DonorValidation();
        var result = validator.Validate(model);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
            throw new ValidationErrorsException(errorMessages);
        }
    }
}
