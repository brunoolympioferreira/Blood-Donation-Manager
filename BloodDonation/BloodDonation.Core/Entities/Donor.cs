using BloodDonation.Core.Enums;

namespace BloodDonation.Core.Entities;
public class Donor : BaseEntity
{
    public Donor(string name, string email, DateTime birthdayDate, GenderEnum gender, double weight, BloodTypesEnum bloodType, RhFatorEnum rhFact)
    {
        Name = name;
        Email = email;
        BirthdayDate = birthdayDate;
        Gender = gender;
        Weight = weight;
        BloodType = bloodType;
        RhFact = rhFact;
    }

    public string Name { get; private set; }
    public string Email { get; private set; }
    public DateTime BirthdayDate { get; private set; }
    public GenderEnum Gender { get; private set; }
    public double Weight { get; private set; }
    public BloodTypesEnum BloodType { get; private set; }
    public RhFatorEnum RhFact { get; private set; }

    public virtual ICollection<Donation> Donations { get; set; }
    public virtual Address Address { get; set; }
}
