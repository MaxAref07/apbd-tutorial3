# apbd-tutorial3
This is a console application that represents a university equipment rental service.
We can add, rent, return, check availability for equipment, add users.
System won't let users to have more than a maximum quantity of active rentals. Past due return will result in a penalty.

Project shows an attempt to address cohesion - models only contain logic that describes them, not anything else. Classes have clear responsibilities. Services have business logic/rules for operations that require knowledge about more than one object, while models have logic to manage their own internal state. Tight coupling is fixed by using Interfaces for DI and registering interfaces implementation to classes (dependency inversion). 

I chose this organization of files because I have the most experience in it and it makes the most sense to me. Every class has clear responsibilities, loose coupling is present, and the project structure is easy to read. I didn't use project layers, because I consider it as an overkill for such a small app.

SOLID is present in my application. Single responsibility - each class is responsible for its own thing. Open-close - you can easily add, say, tablet, or a new user without changing the existing code. Liskov principle - everywhere User is interchangeable with Student or Employee. Interface segregation - my interfaces don't have anything that classes implementing them don't use. I have three interfaces instead of one huge IService. Dependency inversion - my RentalService doesnt depend on a concrete class, it depends on interfaces. In Program I register implementation of interfaces, so its easy to test and interchangeable.

How to run: cd apbd-app2/apbd-app2 && dotnet run