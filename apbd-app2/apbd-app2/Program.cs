using Microsoft.Extensions.DependencyInjection;
using apbd_app2.Domain.Models;
using apbd_app2.Services;

var services = new ServiceCollection();
services.AddSingleton<IEquipmentService, EquipmentService>();
services.AddSingleton<IUserService, UserService>();
services.AddSingleton<IRentalService, RentalService>();

var serviceProvider = services.BuildServiceProvider();
var equipmentService = serviceProvider.GetRequiredService<IEquipmentService>();
var userService = serviceProvider.GetRequiredService<IUserService>();
var rentalService = serviceProvider.GetRequiredService<IRentalService>();

//Add equipment
Console.WriteLine("Adding equipment:");

var laptop = new Laptop("MacBook", 24, 16.5);
var projector = new Projector("Cool Projector", 3600, "1920x1080");
var camera = new Camera("Canon g7x", 20, true);

equipmentService.AddEquipment(laptop);
equipmentService.AddEquipment(projector);
equipmentService.AddEquipment(camera);

Console.WriteLine("Added: " + laptop.Name);
Console.WriteLine("Added: " + projector.Name);
Console.WriteLine("Added: " + camera.Name);

//Add users
Console.WriteLine("\nAdding users:");

var student = new Student("Max", "Arefiev", "s33702");
var employee = new Employee("Oleg", "Suchilin", "IT Department");

userService.AddUser(student);
userService.AddUser(employee);

Console.WriteLine("Added student: " + student.FirstName + " " + student.LastName);
Console.WriteLine("Added employee: " + employee.FirstName + " " + employee.LastName);

//Show all equipment
Console.WriteLine("\nAll equipment:");
foreach (var item in equipmentService.GetAll())
{
    Console.WriteLine(item.Name + " Available: " + item.IsAvailable);
}

//Show available equipment
Console.WriteLine("\nAvailable equipment:");
foreach (var item in equipmentService.GetAvailable())
{
    Console.WriteLine(item.Name);
}

//Successful rental
Console.WriteLine("\nRenting equipment");
var rental1 = rentalService.RentEquipment(student.Id, laptop.Id, DateTime.Now.AddDays(7));
Console.WriteLine(student.FirstName + " rented " + laptop.Name);

var rental2 = rentalService.RentEquipment(student.Id, projector.Id, DateTime.Now.AddDays(3));
Console.WriteLine(student.FirstName + " rented " + projector.Name);

//Invalid rental cause student already has 2 active rentals
Console.WriteLine("\n Invalid rental (user has 2 active rentals)");
try
{
    rentalService.RentEquipment(student.Id, camera.Id, DateTime.Now.AddDays(5));
}
catch (InvalidOperationException e)
{
    Console.WriteLine(e.Message);
}

//Invalid rental cause equipment isnt available
Console.WriteLine("\nInvalid rental (unavailable equipment");
try
{
    rentalService.RentEquipment(employee.Id, laptop.Id, DateTime.Now.AddDays(5));
}
catch (InvalidOperationException e)
{
    Console.WriteLine(e.Message);
}

//Show active rentals for student
Console.WriteLine("\nActive Rentals for " + student.FirstName);
foreach (var r in rentalService.GetActiveRentals(student.Id))
{
    Console.WriteLine(r.Equipment.Name + " Due " + r.DueDate.ToShortDateString());
}

//On time return
Console.WriteLine("\nReturn equipment on time");
var returned1 = rentalService.ReturnEquipment(rental1.Id, DateTime.Now.AddDays(5));
Console.WriteLine("Returned " + returned1.Equipment.Name + "; Penalty is " + returned1.Penalty);

//Late return with penalty
Console.WriteLine("\nReturning equipment late");
var returned2 = rentalService.ReturnEquipment(rental2.Id, DateTime.Now.AddDays(10));
Console.WriteLine("Returned " + returned2.Equipment.Name + " Days late: "
    + (int)(returned2.ActualReturnDate!.Value - returned2.DueDate).TotalDays
    + " Penalty: " + returned2.Penalty);

//Marking equipment as unavailable
Console.WriteLine("\nMarking equipment as unavailable");
equipmentService.MarkAsUnavailable(camera.Id);
Console.WriteLine(camera.Name + " marked as unavailable");

//Display overdue rentals
Console.WriteLine("\nOverdue rentals");
var overdue = rentalService.GetOverdueRentals();
if (overdue.Count == 0)
    Console.WriteLine("No overdue rentals.");
else
    foreach (var r in overdue)
        Console.WriteLine(r.Equipment.Name + " rented by " + r.User.FirstName);

//Report
Console.WriteLine("\n" + rentalService.GenerateReport());
