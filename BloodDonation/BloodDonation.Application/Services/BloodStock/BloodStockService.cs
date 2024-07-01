using BloodDonation.Application.Models.InputModels.BloodStock;
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
}
