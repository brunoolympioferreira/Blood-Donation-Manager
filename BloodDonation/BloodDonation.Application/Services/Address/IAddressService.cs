using BloodDonation.Application.Models.ViewModels.Address;

namespace BloodDonation.Application.Services.Address;
public interface IAddressService
{
    Task<AddressViewModel> GetAddressByViaCep(string cep);
}
