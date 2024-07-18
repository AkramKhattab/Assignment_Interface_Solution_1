using System;
using System.Collections.Generic;

namespace Assignment_Interface_Solution_1_
{
    #region Part 01 - Choose the correct answer :

    // Question 1
    // What is the primary purpose of an interface in C#?
    // Answer: b) To define a blueprint for a class

    // Question 2
    // Which of the following is NOT a valid access modifier for interface members in C#?
    // Answer: a) private

    // Question 3
    // Can an interface contain fields in C#?
    // Answer: b) No

    // Question 4
    // In C#, can an interface inherit from another interface?
    // Answer: b) Yes, interfaces can inherit from multiple interfaces

    // Question 5
    // Which keyword is used to implement an interface in a class in C#?
    // Answer: d) implements

    // Question 6
    // Can an interface contain static methods in C#?
    // Answer: a) Yes

    // Question 7
    // In C#, can an interface have explicit access modifiers for its members?
    // Answer: b) No, all members are implicitly public

    // Question 8
    // What is the purpose of an explicit interface implementation in C#?
    // Answer: b) To provide a clear separation between interface and class members

    // Question 9
    // In C#, can an interface have a constructor?
    // Answer: b) No, interfaces cannot have constructors

    // Question 10
    // How can a C# class implement multiple interfaces?
    // Answer: c) By separating interface names with commas

    #endregion

    #region Part 02 - Implementation :

    // Question 01
    interface IShape
    {
        double Area { get; }
        void DisplayShapeInfo();
    }

    interface ICircle : IShape
    {
        double Radius { get; }
    }

    interface IRectangle : IShape
    {
        double Length { get; }
        double Width { get; }
    }

    class Circle : ICircle
    {
        public double Radius { get; private set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Area => Math.PI * Math.Pow(Radius, 2);

        public void DisplayShapeInfo()
        {
            Console.WriteLine($"Circle with radius {Radius} has an area of {Area:F2}.");
        }
    }

    class Rectangle : IRectangle
    {
        public double Length { get; private set; }
        public double Width { get; private set; }

        public Rectangle(double length, double width)
        {
            Length = length;
            Width = width;
        }

        public double Area => Length * Width;

        public void DisplayShapeInfo()
        {
            Console.WriteLine($"Rectangle with length {Length} and width {Width} has an area of {Area:F2}.");
        }
    }

    // Question 02
    interface IAuthenticationService
    {
        bool AuthenticateUser(string username, string password);
        bool AuthorizeUser(string username, string role);
    }

    class BasicAuthenticationService : IAuthenticationService
    {
        private readonly Dictionary<string, string> _users = new Dictionary<string, string>
        {
            { "admin", "password123" },
            { "user", "pass123" }
        };

        private readonly Dictionary<string, List<string>> _roles = new Dictionary<string, List<string>>
        {
            { "admin", new List<string> { "Admin", "User" } },
            { "user", new List<string> { "User" } }
        };

        public bool AuthenticateUser(string username, string password)
        {
            return _users.TryGetValue(username, out var storedPassword) && storedPassword == password;
        }

        public bool AuthorizeUser(string username, string role)
        {
            return _roles.TryGetValue(username, out var roles) && roles.Contains(role);
        }
    }

    // Question 03
    interface INotificationService
    {
        void SendNotification(string recipient, string message);
    }

    class EmailNotificationService : INotificationService
    {
        public void SendNotification(string recipient, string message)
        {
            Console.WriteLine($"Sending email to {recipient}: {message}");
        }
    }

    class SmsNotificationService : INotificationService
    {
        public void SendNotification(string recipient, string message)
        {
            Console.WriteLine($"Sending SMS to {recipient}: {message}");
        }
    }

    class PushNotificationService : INotificationService
    {
        public void SendNotification(string recipient, string message)
        {
            Console.WriteLine($"Sending push notification to {recipient}: {message}");
        }
    }

    #endregion
    class Program
    {
        static void Main(string[] args)
        {
            // Part 01 Question 01 Testing
            IShape circle = new Circle(5);
            circle.DisplayShapeInfo();

            IShape rectangle = new Rectangle(4, 6);
            rectangle.DisplayShapeInfo();


            // Question 02 - Testing

            IAuthenticationService authService = new BasicAuthenticationService();

            Console.WriteLine(authService.AuthenticateUser("admin", "password123")); // True
            Console.WriteLine(authService.AuthorizeUser("admin", "Admin")); // True

            Console.WriteLine(authService.AuthenticateUser("user", "wrongpass")); // False
            Console.WriteLine(authService.AuthorizeUser("user", "Admin")); // False

            // Question 03 - Testing

            INotificationService emailService = new EmailNotificationService();
            emailService.SendNotification("email@example.com", "Hello via Email!");

            INotificationService smsService = new SmsNotificationService();
            smsService.SendNotification("123-456-7890", "Hello via SMS!");

            INotificationService pushService = new PushNotificationService();
            pushService.SendNotification("user1", "Hello via Push Notification!");
        }
    }

    #region Part 03 - Explaining how Clone creates a shallow copy:
    
    /*
     * 
    namespace CloneExample
    {
        // Define a class with a few properties
        public class Person
        {
            public string Name { get; set; }
            public Address Address { get; set; }

            // Implement the Clone method to create a shallow copy
            public Person Clone()
            {
                // Create a new instance of Person and copy the values of the current instance
                return new Person
                {
                    Name = this.Name,
                    Address = this.Address
                     This creates a shallow copy because only the reference to the Address object is copied, not the object itself.
                };
            }
        }

        // Define another class to be used as a property in the Person class
        public class Address
        {
            public string Street { get; set; }
            public string City { get; set; }
        }

class Program
{
    static void Main(string[] args)
    {
        // Create a new instance of Person
        Person person1 = new Person
        {
            Name = "John",
            Address = new Address { Street = "123 Main St", City = "Anytown" }
        };

        // Clone person1 to create a shallow copy
        Person person2 = person1.Clone();

        // Display original and cloned person's details
        Console.WriteLine($"Person1 Name: {person1.Name}, Address: {person1.Address.Street}, {person1.Address.City}");
        Console.WriteLine($"Person2 Name: {person2.Name}, Address: {person2.Address.Street}, {person2.Address.City}");

        // Modify the address of the cloned person
        person2.Address.Street = "456 Elm St";

        // Display the details again to see the effect of the shallow copy
        Console.WriteLine($"After modification:");
        Console.WriteLine($"Person1 Name: {person1.Name}, Address: {person1.Address.Street}, {person1.Address.City}");
        Console.WriteLine($"Person2 Name: {person2.Name}, Address: {person2.Address.Street}, {person2.Address.City}");

        *Notice how changing the Address property of person2 also affects person1.
                 *This is because the Address property was copied by reference, not by value.
                 *Both person1 and person2 share the same Address object.
            }
       } 

    */

    #endregion
