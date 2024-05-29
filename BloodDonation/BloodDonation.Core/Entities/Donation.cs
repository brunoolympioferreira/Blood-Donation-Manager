namespace BloodDonation.Core.Entities;
public class Donation : BaseEntity
{
    public Donation(Guid donorId, DateTime donationDate, int mLQuantity)
    {
        DonorId = donorId;
        DonationDate = donationDate;
        MLQuantity = mLQuantity;
    }

    public Guid DonorId { get; private set; }
    public DateTime DonationDate { get; private set; }
    public int MLQuantity { get; private set; }

    public virtual Donor Donor { get; set; }
}
