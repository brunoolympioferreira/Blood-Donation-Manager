using BloodDonation.Core.Entities;
using BloodDonation.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodDonation.Infra.Persistence.Configurations;
public class BloodStockConfiguration : IEntityTypeConfiguration<BloodStock>
{
    public void Configure(EntityTypeBuilder<BloodStock> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.BloodType).IsRequired().HasConversion<string>();
        builder.Property(b => b.RhFactor).IsRequired().HasConversion<string>();
        builder.Property(b => b.MLQuantity).IsRequired();

        builder.HasData(Seed());


    }

    private static List<BloodStock> Seed()
    {
        return
        [
            new(BloodTypesEnum.A, RhFatorEnum.Positive, 0),
            new(BloodTypesEnum.A, RhFatorEnum.Negative, 0),
            new(BloodTypesEnum.B, RhFatorEnum.Positive, 0),
            new(BloodTypesEnum.B, RhFatorEnum.Negative, 0),
            new(BloodTypesEnum.AB, RhFatorEnum.Positive, 0),
            new(BloodTypesEnum.AB, RhFatorEnum.Negative, 0),
            new(BloodTypesEnum.O, RhFatorEnum.Positive, 0),
            new(BloodTypesEnum.O, RhFatorEnum.Negative, 0)
        ];
    }
}
