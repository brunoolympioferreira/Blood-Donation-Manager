using BloodDonation.Core.Entities;
using BloodDonation.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BloodDonation.Infra.Persistence.Repositories;
public class DonorRepository(BloodDonationDbContext context) : IDonorRepository
{
    private readonly BloodDonationDbContext _context = context;

    public async Task AddAsync(Donor donor)
    {
        await _context.AddAsync(donor);
    }

    public async Task<bool> ExistEmailAsync(string email)
    {
        var existEmail = await _context.Donors.AnyAsync(x => x.Email.Equals(email));

        return existEmail;
    }

    public async Task<Donor> GetByIdAsync(Guid id)
    {
        Donor? donor = await _context.Donors
            .AsNoTracking()
            .Include(d => d.Donations)
            .SingleOrDefaultAsync(d => d.Id == id);

        return donor;
    }
}
