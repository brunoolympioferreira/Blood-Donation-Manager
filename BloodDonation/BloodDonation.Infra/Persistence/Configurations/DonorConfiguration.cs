using BloodDonation.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodDonation.Infra.Persistence.Configurations;
public class DonorConfiguration : IEntityTypeConfiguration<Donor>
{
    public void Configure(EntityTypeBuilder<Donor> builder)
    {
        builder.HasKey(d => d.Id);

        builder.Property(d => d.Name).HasMaxLength(200).IsRequired();
        builder.Property(d => d.Email).HasMaxLength(100).IsRequired();
        builder.Property(d => d.BirthdayDate).IsRequired();
        builder.Property(d => d.Gender).HasConversion<string>().IsRequired();
        builder.Property(d => d.Weight).IsRequired();
        builder.Property(d => d.BloodType).HasConversion<string>().IsRequired();
        builder.Property(d => d.RhFact).HasConversion<string>().IsRequired();
    }
}
