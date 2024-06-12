namespace BloodDonation.Core.Entities;
public class User(string name, string password, string email) : BaseEntity
{
    public string Name { get; private set; } = name;
    public string Password { get; private set; } = password;
    public string Email { get; private set; } = email;
}
