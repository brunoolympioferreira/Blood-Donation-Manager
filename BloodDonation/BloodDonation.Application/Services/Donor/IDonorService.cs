using BloodDonation.Application.Models.InputModels.Donor;

namespace BloodDonation.Application.Services.Donor;
public interface IDonorService
{
    Task<Guid> Create(DonorInputModel model);
}
