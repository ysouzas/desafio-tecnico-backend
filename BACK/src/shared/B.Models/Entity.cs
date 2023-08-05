namespace B.Models;

public abstract class Entity
{
    public Guid Id { get; set; }

    public DateTimeOffset Created { get; set; }

    public DateTimeOffset? Updated { get; set; }

    protected Entity()
    {
        Id = Guid.NewGuid();
        Created = DateTimeOffset.Now;
    }
}

