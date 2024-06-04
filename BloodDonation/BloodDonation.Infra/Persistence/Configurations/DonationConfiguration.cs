using BloodDonation.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodDonation.Infra.Persistence.Configurations;
public class DonationConfiguration : IEntityTypeConfiguration<Donation>
{
    public void Configure(EntityTypeBuilder<Donation> builder)
    {
        builder.HasKey(d => d.Id);

        builder.Property(d => d.DonationDate).IsRequired();
        builder.Property(d => d.MLQuantity).IsRequired();
    }
}
