using BloodDonation.Core.Enums;

namespace BloodDonation.Core.Entities;
public class Address : BaseEntity
{
    public Address(string street, string city, string state, string cEP)
    {
        Street = street;
        City = city;
        State = state;
        CEP = cEP;
    }

    public Address()
    {
        
    }

    public string Street { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string CEP { get; private set; }
}
