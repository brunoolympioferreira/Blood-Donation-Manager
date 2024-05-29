namespace BloodDonation.Core.Entities;
public abstract class BaseEntity()
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; private set; } = DateTime.Now;
    public DateTime UpdatedAt { get; private set; }

    public void LastUpdatedAt(DateTime updatedAt)
    {
        UpdatedAt = updatedAt;
    }
}
