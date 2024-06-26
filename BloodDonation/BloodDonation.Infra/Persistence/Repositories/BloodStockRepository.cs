using BloodDonation.Core.Entities;
using BloodDonation.Core.Repositories;

namespace BloodDonation.Infra.Persistence.Repositories;
public class BloodStockRepository : IBloodStockRepository
{
    private readonly BloodDonationDbContext _context;
    public BloodStockRepository(BloodDonationDbContext context)
    {
        _context = context;
    }
    public async Task AddAsync(BloodStock bloodStock)
    {
        await _context.AddAsync(bloodStock);
    }
}
