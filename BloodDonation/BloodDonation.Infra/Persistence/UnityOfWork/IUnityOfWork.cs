namespace BloodDonation.Infra.Persistence.UnityOfWork;
public interface IUnityOfWork
{
    Task<int> CompleteAsync();
}
