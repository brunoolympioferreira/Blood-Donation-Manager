using BloodDonation.Core.Entities;
using BloodDonation.Core.Enums;

namespace BloodDonation.Core.Repositories;
public interface IBloodStockRepository
{
    void Update(BloodStock bloodStock);
    Task<BloodStock> GetByParams(BloodTypesEnum bloodType, RhFatorEnum rhFactor);
    Task<List<BloodStock>> GetAllAsync();
}
