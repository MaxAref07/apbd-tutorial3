namespace apbd_app2.Domain.Models;

public class Student : User
{
    public string StudentNumber { get; private set; }

    public override int MaxActiveRentals => 2;
    public override string UserType => "Student";

    public Student(string firstName, string lastName, string studentNumber) : base(firstName, lastName)
    {
        StudentNumber = studentNumber;
    }
}