using BloodDonation.Core.Entities;

namespace BloodDonation.Core.Repositories;
public interface IUserRepository
{
    Task AddAsync(User user);

    Task<bool> ExistUserWithEmail(string email, Guid id);
}
