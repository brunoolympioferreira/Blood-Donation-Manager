using BloodDonation.Core.Entities;
using System.Text.Json;

namespace BloodDonation.Infra.ViaCep;
public class ViaCepClient : IViaCepClient
{
    private static readonly HttpClient client = new();

    public async Task<Address> GetAddressAsync(string cep)
    {
        string url = $"https://viacep.com.br/ws/{cep}/json/";
        HttpResponseMessage response = await client.GetAsync(url);

        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
  
        AddressDTO viewModel = JsonSerializer.Deserialize<AddressDTO>(responseBody, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        }) ?? throw new Exception("Houve um problema ao buscar o CEP");

        Address address = viewModel.ToEntity();

        return address;
    }
}
