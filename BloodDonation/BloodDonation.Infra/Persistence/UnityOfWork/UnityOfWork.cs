using BloodDonation.Core.Repositories;

namespace BloodDonation.Infra.Persistence.UnityOfWork;
public class UnityOfWork : IUnityOfWork
{
    private BloodDonationDbContext _context;
    public UnityOfWork(BloodDonationDbContext context,
        IUserRepository users,
        IDonorRepository donors,
        IDonationRepository donations,
        IBloodStockRepository bloodStocks)
    {
        _context = context;
        Users = users;
        Donors = donors;
        Donations = donations;
        BloodStocks = bloodStocks;
    }
    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public IUserRepository Users { get; }
    public IDonorRepository Donors { get; }
    public IDonationRepository Donations { get; }
    public IBloodStockRepository BloodStocks { get; }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _context.Dispose();
        }
    }
}
