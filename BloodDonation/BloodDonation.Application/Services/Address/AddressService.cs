using BloodDonation.Application.Models.ViewModels.Address;
using BloodDonation.Infra.ViaCep;

namespace BloodDonation.Application.Services.Address;
public class AddressService(IViaCepClient client) : IAddressService
{
    public async Task<AddressViewModel> GetAddressByViaCep(string cep)
    {
        Core.Entities.Address address = await client.GetAddressAsync(cep);

        AddressViewModel viewModel = new(address);

        return viewModel;
    }
}
