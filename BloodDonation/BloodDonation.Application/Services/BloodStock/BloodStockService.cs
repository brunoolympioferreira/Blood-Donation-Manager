using BloodDonation.Application.Models.InputModels.BloodStock;
using BloodDonation.Application.Models.ViewModels.BloodStock;
using BloodDonation.Infra.Persistence.UnityOfWork;

namespace BloodDonation.Application.Services.BloodStock;
public class BloodStockService(IUnityOfWork unityOfWork) : IBloodStockService
{
    private readonly IUnityOfWork _unityOfWork = unityOfWork;

    public async Task Update(BloodStockInputModel model)
    {
        Core.Entities.BloodStock bloodStock = await _unityOfWork.BloodStocks.GetByParams(model.BloodType, model.RhFactor);

        bloodStock.Update(model.MLQuantity);

        _unityOfWork.BloodStocks.Update(bloodStock);
    }

    public async Task<List<BloodStockViewModel>> StockReport()
    {
        List<Core.Entities.BloodStock> stock = await _unityOfWork.BloodStocks.GetAllAsync();
        Dictionary<string, int> bloodTypes = [];

        foreach (var stockItem in stock)
        {
            bloodTypes.Add($"{stockItem.BloodType} {stockItem.RhFactor}",stockItem.MLQuantity);
        }

        List<BloodStockViewModel> report = bloodTypes.Select(r => new BloodStockViewModel(r.Key, r.Value)).ToList();

        return report;
    }
}
