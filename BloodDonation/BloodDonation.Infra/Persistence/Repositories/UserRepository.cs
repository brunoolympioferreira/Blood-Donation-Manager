using BloodDonation.Core.Entities;
using BloodDonation.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BloodDonation.Infra.Persistence.Repositories;
public class UserRepository(BloodDonationDbContext context) : IUserRepository
{
    private readonly BloodDonationDbContext _context = context;

    public async Task AddAsync(User user)
    {
        await _context.AddAsync(user);
    }

    public async Task<bool> ExistUserWithEmail(string email, Guid id)
    {
        return await _context.Users
            .AsNoTracking()
            .AnyAsync(u => u.Email.Equals(email) && u.Id != id);
    }

    public async Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash)
    {
        User? user = await _context.Users.AsNoTracking().SingleOrDefaultAsync(u => u.Email == email && u.Password == passwordHash);
        return user;
    }
}
