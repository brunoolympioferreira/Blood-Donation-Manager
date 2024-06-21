using BloodDonation.Core.Entities;
using BloodDonation.Core.Enums;

namespace BloodDonation.Application.Models.InputModels.Donor;
public class DonorInputModel
{
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime BirthdayDate { get; set; }
    public GenderEnum Gender { get; set; }
    public double Weight { get; set; }
    public BloodTypesEnum BloodType { get; set; }
    public RhFatorEnum RhFact { get; set; }
    public string CEP { get; set; }

    public Core.Entities.Donor ToEntity(Address address) => new(Name, Email, BirthdayDate, Gender, Weight, BloodType, RhFact, address);
}
