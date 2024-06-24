using BloodDonation.Core.Entities;
using BloodDonation.Core.Repositories;

namespace BloodDonation.Infra.Persistence.Repositories;
public class DonationRepository(BloodDonationDbContext context) : IDonationRepository
{
    private readonly BloodDonationDbContext _context = context;

    public async Task AddAsync(Donation donation)
    {
        await _context.AddAsync(donation);
    }
}
