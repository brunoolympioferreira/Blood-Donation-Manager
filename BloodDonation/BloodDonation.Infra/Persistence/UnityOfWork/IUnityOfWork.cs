using BloodDonation.Core.Repositories;

namespace BloodDonation.Infra.Persistence.UnityOfWork;
public interface IUnityOfWork
{
    IUserRepository Users {  get; }
    Task<int> CompleteAsync();
}
