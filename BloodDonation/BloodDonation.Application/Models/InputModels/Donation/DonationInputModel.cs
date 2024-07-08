namespace BloodDonation.Application.Models.InputModels.Donation;
public class DonationInputModel
{
    public Guid DonorId { get; set; }
    public DateTime DonationDate { get; set; }
    public int MLQuantity { get; set; }

    public Core.Entities.Donation ToEntity() => new(DonorId, DonationDate, MLQuantity);
}
