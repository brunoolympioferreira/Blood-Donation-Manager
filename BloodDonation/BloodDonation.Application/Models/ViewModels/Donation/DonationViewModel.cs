namespace BloodDonation.Application.Models.ViewModels.Donation;
public class DonationViewModel
{
    public DonationViewModel(Core.Entities.Donation donation)
    {
        DonationDate = donation.DonationDate;
        MLQuantity = donation.MLQuantity;
    }

    public DateTime DonationDate { get; set; }
    public int MLQuantity { get; set; }
}
