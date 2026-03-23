using Ardalis.GuardClauses;

namespace apbd_app2.Domain.Models;

public abstract class User
{
    public Guid Id { get; init; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public abstract int MaxActiveRentals { get; }

    protected User(string firstName, string lastName)
    {
        Guard.Against.NullOrEmpty(firstName, nameof(firstName));
        Guard.Against.NullOrEmpty(lastName, nameof(lastName));
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
    }

    public void SetFirstName(string firstName)
    {
        Guard.Against.NullOrEmpty(firstName, nameof(firstName));
        FirstName = firstName;
    }

    public void SetLastName(string lastName)
    {
        Guard.Against.NullOrEmpty(lastName, nameof(lastName));
        LastName = lastName;
    }
}