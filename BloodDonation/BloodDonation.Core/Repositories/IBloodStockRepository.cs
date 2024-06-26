using BloodDonation.Core.Entities;

namespace BloodDonation.Core.Repositories;
public interface IBloodStockRepository
{
    Task AddAsync(BloodStock bloodStock);
}
