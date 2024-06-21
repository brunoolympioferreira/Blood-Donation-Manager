using BloodDonation.Core.Entities;
using BloodDonation.Core.Repositories;

namespace BloodDonation.Infra.Persistence.Repositories;
public class DonorRepository : IDonorRepository
{
    private readonly BloodDonationDbContext _context;
    public DonorRepository(BloodDonationDbContext context)
    {
        _context = context;
    }
    public async Task AddAsync(Donor donor)
    {
        await _context.AddAsync(donor);
    }
}
