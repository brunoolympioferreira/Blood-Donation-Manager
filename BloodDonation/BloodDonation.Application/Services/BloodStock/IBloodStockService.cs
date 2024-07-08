using BloodDonation.Application.Models.InputModels.BloodStock;
using BloodDonation.Application.Models.ViewModels.BloodStock;

namespace BloodDonation.Application.Services.BloodStock;
public interface IBloodStockService
{
    Task Update(BloodStockInputModel model);
    Task<List<BloodStockViewModel>> StockReport();
}
