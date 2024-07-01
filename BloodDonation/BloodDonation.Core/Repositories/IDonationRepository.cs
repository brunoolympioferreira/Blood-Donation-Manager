using BloodDonation.Core.Entities;

namespace BloodDonation.Core.Repositories;
public interface IDonationRepository
{
    Task AddAsync(Donation donation);
}
