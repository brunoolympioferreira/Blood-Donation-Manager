using BloodDonation.Core.Entities;

namespace BloodDonation.Infra.ViaCep;
public interface IViaCepClient
{
    public Task<Address> GetAddressAsync(string cep);
}
