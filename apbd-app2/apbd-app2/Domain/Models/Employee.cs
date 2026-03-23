namespace apbd_app2.Domain.Models;

public class Employee : User
{
    public string Department { get; private set; }

    public override int MaxActiveRentals => 5;
    public override string UserType => "Employee";


    public Employee(string firstName, string lastName, string department) : base(firstName, lastName)
    {
        Department = department;
    }
}