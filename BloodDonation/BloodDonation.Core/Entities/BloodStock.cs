using BloodDonation.Core.Enums;

namespace BloodDonation.Core.Entities;
public class BloodStock : BaseEntity
{
    public BloodStock(BloodTypesEnum bloodType, RhFatorEnum rhFactor, int mLQuantity)
    {
        BloodType = bloodType;
        RhFactor = rhFactor;
        MLQuantity = mLQuantity;
    }

    public BloodTypesEnum BloodType { get; private set; }
    public RhFatorEnum RhFactor { get; private set; }
    public int MLQuantity { get; private set; }
}
