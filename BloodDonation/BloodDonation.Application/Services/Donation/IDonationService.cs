using BloodDonation.Application.Models.InputModels.Donation;
using BloodDonation.Application.Models.ViewModels.Donation;

namespace BloodDonation.Application.Services.Donation;
public interface IDonationService
{
    Task<Guid> Register(DonationInputModel model);
    Task<List<DonationViewModel>> GetByDonor(Guid donorId);
    Task<List<DonationDetailViewModel>> GetAll();
}
