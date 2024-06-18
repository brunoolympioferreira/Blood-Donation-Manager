using BloodDonation.Core.Enums;

namespace BloodDonation.Application.Models.ViewModels.Address;
public class AddressViewModel
{
    public AddressViewModel(Core.Entities.Address address)
    {
        Street = address.Street;
        City = address.City;
        State = address.State;
        CEP = address.CEP;
    }

    public string Street { get; }
    public string City { get; }
    public StatesEnum State { get; }
    public string CEP { get; }
}
