namespace IG_Train.Domain.Entities;

public abstract class BaseEntity<TKey>
{
    protected BaseEntity(TKey key)
    {
        Id = key;
    }

    public TKey Id { get; }
}
