using BloodDonation.Application.Models.ViewModels.Address;
using BloodDonation.Core.Enums;

namespace BloodDonation.Application.Models.ViewModels.Donor;
public class DonorDetailViewModel
{
    public DonorDetailViewModel(Core.Entities.Donor donor)
    {
        Name = donor.Name;
        Email = donor.Email;
        BirthdayDate = donor.BirthdayDate;
        Gender = donor.Gender;
        Weight = donor.Weight;
        BloodType = donor.BloodType;
        RhFact = donor.RhFact;
        Address = new AddressViewModel(donor.Address);
    }
    public string Name { get; }
    public string Email { get; }
    public DateTime BirthdayDate { get; }
    public GenderEnum Gender { get; }
    public double Weight { get; }
    public BloodTypesEnum BloodType { get; }
    public RhFatorEnum RhFact { get; }
    public AddressViewModel Address { get; }
}
