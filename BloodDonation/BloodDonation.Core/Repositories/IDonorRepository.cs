using BloodDonation.Core.Entities;

namespace BloodDonation.Core.Repositories;
public interface IDonorRepository
{
    Task AddAsync(Donor donor);
    Task<bool> ExistEmailAsync(string email);
    Task<Donor> GetByIdAsync(Guid id);
}
