using Ardalis.GuardClauses;

namespace apbd_app2.Domain.Models;

public abstract class Equipment
{
    public Guid Id { get; init; }
    public string Name { get; private set; }
    public bool IsAvailable { get; private set; }

    public Equipment(string name)
    {
        Guard.Against.NullOrEmpty(name, nameof(name));
        Name = name;
        IsAvailable = true;
        Id = Guid.NewGuid();
    }

    public void SetName(string name)
    {
        Guard.Against.NullOrEmpty(name, nameof(name));
        Name = name;
    }

    public void MarkAsAvailable()
    {
        IsAvailable = true;
    }

    public void MarkAsUnavailable()
    {
        IsAvailable = false;
    }
}