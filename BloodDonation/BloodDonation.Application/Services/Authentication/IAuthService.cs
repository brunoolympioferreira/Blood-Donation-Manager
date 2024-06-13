namespace BloodDonation.Application.Services.Authentication;
public interface IAuthService
{
    string GenerateJwtToken(Core.Entities.User user);
    string ComputeSha256Hash(string password);
}
