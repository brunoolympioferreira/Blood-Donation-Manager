using BloodDonation.Core.Entities;
using BloodDonation.Core.Enums;

namespace BloodDonation.Infra.ViaCep;
public class AddressDTO
{
    public string Logradouro { get; set; }
    public string Localidade { get; set; }
    public string UF { get; set; }
    public string CEP { get; set; }

    public Address ToEntity() => new(Logradouro, Localidade, UF, CEP);
}
