namespace apbd_app2.Domain.Models;

public class Employee : User
{
    public string Department { get; private set; }

    public override int MaxActiveRentals => 5;

    public Employee(string firstName, string lastName, string department) : base(firstName, lastName)
    {
        Department = department;
    }
}