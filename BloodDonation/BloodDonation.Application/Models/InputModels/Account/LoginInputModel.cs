namespace BloodDonation.Application.Models.InputModels.Account;
public class LoginInputModel
{
    public string Email { get; set; }
    public string Password { get; set; }

    public Core.Entities.User ToEntity() => new(Email, Password);
}
