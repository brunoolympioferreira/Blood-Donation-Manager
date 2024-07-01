using BloodDonation.Application.Models.InputModels.Donation;

namespace BloodDonation.Application.Services.Donation;
public interface IDonationService
{
    Task<Guid> Register(DonationInputModel model);
}
