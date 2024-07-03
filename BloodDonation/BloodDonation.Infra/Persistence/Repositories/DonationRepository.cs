using BloodDonation.Core.Entities;
using BloodDonation.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BloodDonation.Infra.Persistence.Repositories;
public class DonationRepository(BloodDonationDbContext context) : IDonationRepository
{
    private readonly BloodDonationDbContext _context = context;

    public async Task AddAsync(Donation donation)
    {
        await _context.AddAsync(donation);
    }

    public async Task<List<Donation>> GetByDonorIdAsync(Guid donorId)
    {
        List<Donation> donation = await _context.Donations.Where(d => d.DonorId == donorId).ToListAsync();

        return donation;
    }
}
