using BloodDonation.Application.Models.ViewModels.Donor;

namespace BloodDonation.Application.Models.ViewModels.Donation;
public class DonationDetailViewModel
{
    public DonationDetailViewModel(Core.Entities.Donation donation)
    {
        DonationDate = donation.DonationDate;
        MLQuantity = donation.MLQuantity;
        Donor = new DonorDetailViewModel(donation.Donor);
    }
    public DateTime DonationDate { get; }
    public int MLQuantity { get; }
    public DonorDetailViewModel Donor { get; }
}
