using BloodDonation.Application.Models.InputModels.Donor;
using BloodDonation.Core.Exceptions;
using BloodDonation.Infra.Persistence.UnityOfWork;
using BloodDonation.Infra.ViaCep;

namespace BloodDonation.Application.Services.Donor;
public class DonorService : IDonorService
{
    private readonly IUnityOfWork _unityOfWork;
    private readonly IViaCepClient _viaCepClient;
    public DonorService(IUnityOfWork unityOfWork, IViaCepClient viaCepClient)
    {
        _unityOfWork = unityOfWork;
        _viaCepClient = viaCepClient;
    }

    public async Task<Guid> Create(DonorInputModel model)
    {
        ValidateModel(model);

        bool existEmail = await _unityOfWork.Donors.ExistEmailAsync(model.Email);

        if (existEmail)
            throw new ValidationErrorsException("E-mail já existe na base de dados");

        Core.Entities.Address address = await _viaCepClient.GetAddressAsync(model.CEP);

        Core.Entities.Donor donor = model.ToEntity(address);

        await _unityOfWork.Donors.AddAsync(donor);

        await _unityOfWork.CompleteAsync();

        return donor.Id;
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
