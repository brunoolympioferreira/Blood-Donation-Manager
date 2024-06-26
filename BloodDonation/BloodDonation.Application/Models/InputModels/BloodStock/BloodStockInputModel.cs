using BloodDonation.Core.Enums;

namespace BloodDonation.Application.Models.InputModels.BloodStock;
public class BloodStockInputModel
{
    public BloodTypesEnum BloodType { get; set; }
    public RhFatorEnum RhFactor { get; set; }
    public int MLQuantity { get; set; }
}
