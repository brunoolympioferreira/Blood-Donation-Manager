using BloodDonation.Core.Enums;

namespace BloodDonation.Core.Entities;
public class Address : BaseEntity
{
    public Address(string street, string city, StatesEnum state, string cEP)
    {
        Street = street;
        City = city;
        State = state;
        CEP = cEP;
    }

    public string Street { get; private set; }
    public string City { get; private set; }
    public StatesEnum State { get; private set; }
    public string CEP { get; private set; }

    public virtual Donor Donor { get; set; }
}
