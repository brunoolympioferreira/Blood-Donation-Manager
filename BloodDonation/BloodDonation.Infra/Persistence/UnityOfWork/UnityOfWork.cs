namespace BloodDonation.Infra.Persistence.UnityOfWork;
public class UnityOfWork : IUnityOfWork
{
    private BloodDonationDbContext _context;
    public UnityOfWork(BloodDonationDbContext context)
    {
        _context = context;
    }
    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

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
