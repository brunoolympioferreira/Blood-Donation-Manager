using BloodDonation.Core.Entities;
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
    }
}
