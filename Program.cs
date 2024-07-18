#region Interface

/*
Definition:
An interface in C# is a contract that defines a set of methods and properties that a class must implement.
Interfaces do not provide implementations for the methods; they only specify what methods must be provided by the implementing class.

// Example 01:

public interface IAnimal
{
    void Speak();
}

public class Dog : IAnimal
{
    public void Speak()
    {
        Console.WriteLine("Woof!");
    }
}

public class Cat : IAnimal
{
    public void Speak()
    {
        Console.WriteLine("Meow!");
    }
}

// Usage
IAnimal dog = new Dog();
dog.Speak(); // Output: Woof!

IAnimal cat = new Cat();
cat.Speak(); // Output: Meow!


// Example 2: Interface with Properties:


public interface IVehicle
{
    int Wheels { get; }
    void Drive();
}

public class Car : IVehicle
{
    public int Wheels { get; } = 4;

    public void Drive()
    {
        Console.WriteLine("Driving a car.");
    }
}

public class Bike : IVehicle
{
    public int Wheels { get; } = 2;

    public void Drive()
    {
        Console.WriteLine("Riding a bike.");
    }
}

// Usage
IVehicle car = new Car();
Console.WriteLine(car.Wheels); // Output: 4
car.Drive(); // Output: Driving a car.

IVehicle bike = new Bike();
Console.WriteLine(bike.Wheels); // Output: 2
bike.Drive(); // Output: Riding a bike.



*/
#endregion

#region Shallow Copy and Deep Copy ("Array of Value Types")
/*

Definition:

Shallow Copy: Copies the references of objects, not the actual objects. If one object changes, the other reflects this change.
Deep Copy: Copies the actual objects. Changes to one object do not affect the other.

 

// Example 1: Shallow Copy of an Array of Value Types

int[] originalArray = { 1, 2, 3 };
int[] shallowCopy = (int[])originalArray.Clone();

shallowCopy[0] = 100;

Console.WriteLine(originalArray[0]); // Output: 1
Console.WriteLine(shallowCopy[0]); // Output: 100



// Example 2: Deep Copy of an Array of Value Types


int[] originalArray = { 1, 2, 3 };
int[] deepCopy = new int[originalArray.Length];

for (int i = 0; i < originalArray.Length; i++)
{
    deepCopy[i] = originalArray[i];
}

deepCopy[0] = 100;

Console.WriteLine(originalArray[0]); // Output: 1
Console.WriteLine(deepCopy[0]); // Output: 100


 */
#endregion

#region Built-in Interface ICloneable
/*
  Definition: ICloneable interface provides a mechanism to create a copy of the current object. 
 
// Example 1: Implementing ICloneable for a Class

public class Person : ICloneable
{
    public string Name { get; set; }
    public int Age { get; set; }

    public object Clone()
    {
        return new Person { Name = this.Name, Age = this.Age };
    }
}

// Usage
Person person1 = new Person { Name = "Alice", Age = 25 };
Person person2 = (Person)person1.Clone();

person2.Name = "Bob";

Console.WriteLine(person1.Name); // Output: Alice
Console.WriteLine(person2.Name); // Output: Bob




// Example 2: Cloning a Complex Object

public class Address : ICloneable
{
    public string Street { get; set; }
    public string City { get; set; }

    public object Clone()
    {
        return new Address { Street = this.Street, City = this.City };
    }
}

public class Employee : ICloneable
{
    public string Name { get; set; }
    public Address Address { get; set; }

    public object Clone()
    {
        Employee clone = (Employee)this.MemberwiseClone();
        clone.Address = (Address)this.Address.Clone();
        return clone;
    }
}

// Usage
Employee emp1 = new Employee { Name = "John", Address = new Address { Street = "123 St", City = "NYC" } };
Employee emp2 = (Employee)emp1.Clone();

emp2.Address.City = "LA";

Console.WriteLine(emp1.Address.City); // Output: NYC
Console.WriteLine(emp2.Address.City); // Output: LA

 */
#endregion

#region Built-in Interface IComparable
/*
Definition: IComparable interface is used to define a standard way to compare objects of a specific type, typically for sorting.


// Example 1: Implementing IComparable for a Simple Class

public class Student : IComparable<Student>
{
    public string Name { get; set; }
    public int Grade { get; set; }

    public int CompareTo(Student other)
    {
        return this.Grade.CompareTo(other.grade);
    }
}

// Usage
List<Student> students = new List<Student>
{
    new Student { Name = "Alice", Grade = 85 },
    new Student { Name = "Bob", Grade = 90 },
    new Student { Name = "Charlie", Grade = 80 }
};

students.Sort();

foreach (var student in students)
{
    Console.WriteLine($"{student.Name}: {student.Grade}");
}
// Output:
// Charlie: 80
// Alice: 85
// Bob: 90



// Example 2: Sorting Custom Objects

public class Book : IComparable<Book>
{
    public string Title { get; set; }
    public int Pages { get; set; }

    public int CompareTo(Book other)
    {
        return this.Pages.CompareTo(other.Pages);
    }
}

// Usage
List<Book> books = new List<Book>
{
    new Book { Title = "Book A", Pages = 200 },
    new Book { Title = "Book B", Pages = 150 },
    new Book { Title = "Book C", Pages = 300 }
};

books.Sort();

foreach (var book in books)
{
    Console.WriteLine($"{book.Title}: {book.Pages} pages");
}
// Output:
// Book B: 150 pages
// Book A: 200 pages
// Book C: 300 pages

*/
#endregion

#region Built-in Interface IComparer
/*
Definition: IComparer interface provides a way to compare two objects, typically used for custom sorting algorithms.


// Example 1: Implementing IComparer for Custom Sorting



public class AgeComparer : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        return x.Age.CompareTo(y.Age);
    }
}

// Usage
List<Person> people = new List<Person>
{
    new Person { Name = "Alice", Age = 30 },
    new Person { Name = "Bob", Age = 25 },
    new Person { Name = "Charlie", Age = 35 }
};

people.Sort(new AgeComparer());

foreach (var person in people)
{
    Console.WriteLine($"{person.Name}: {person.Age}");
}
// Output:
// Bob: 25
// Alice: 30
// Charlie: 35



// Example 2: Sorting by Multiple Criteria

public class NameLengthComparer : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        return x.Name.Length.CompareTo(y.Name.Length);
    }
}

// Usage
List<Person> people = new List<Person>
{
    new Person { Name = "Alice", Age = 30 },
    new Person { Name = "Bob", Age = 25 },
    new Person { Name = "Charlie", Age = 35 }
};

people.Sort(new NameLengthComparer());

foreach (var person in people)
{
    Console.WriteLine($"{person.Name}: {person.Name.Length} characters");
}
// Output:
// Bob: 3 characters
// Alice: 5 characters
// Charlie: 7 characters

*/
#endregion