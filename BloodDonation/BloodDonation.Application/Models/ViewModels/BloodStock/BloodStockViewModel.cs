namespace BloodDonation.Application.Models.ViewModels.BloodStock;
public class BloodStockViewModel
{
    public BloodStockViewModel(string bloodType, int mlQuantity)
    {
        BloodType = bloodType;
        MlQuantity = mlQuantity;
    }
    public string BloodType { get; }
    public int MlQuantity { get; }
}
