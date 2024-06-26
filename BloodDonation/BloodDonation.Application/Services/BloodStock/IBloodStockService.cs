using BloodDonation.Application.Models.InputModels.BloodStock;

namespace BloodDonation.Application.Services.BloodStock;
public interface IBloodStockService
{
    Task Update(BloodStockInputModel model);
}
