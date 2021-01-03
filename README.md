# CSharpIntermediate

CLASSES Introduction  -Classes are building blocks of software applications. 
-A class encapsulates data (stored in fields) and behaviour (defined by methods).
public class Customer {    
public string Name; // Field     
public void Promote()        {      }}// Method    
-An object is an instance of a class. We can create an object using the new operator. 
Customer customer = new Customer();// Or
var customer = new Customer();
Constructors  -A constructor is a method that is called when an instance of a class is created.
-We use constructors to put an object in an early state.
-As a best practice, define a constructor only when an object “needs” to be initialised or it won’t be able to do its job.
-Constructors do not have a return type, not even void, and they should have the exact same name as the class. 
-A quick way to create a constructor: type ctor and press tab. This is a code snippet.
-Constructors can be overloaded. Overloading means creating a method with the same name and different signatures. 
-Signature of a method consists of the number, type and order of its parameters.
-We can pass control from one constructor to the other by using the this keyword.
public class Customer {       
public int Id;       public string Name;       public List<Order> Orders;      // Default or parameterless constructor       
public Customer()       {           
//Orders has to be initialized here,otherwise it//will be a null reference.As a best practice,//anytime your class contains a list, always//initialize the list.             
  Orders = new List<Order>();       }       
  public Customer(int id)          
  : this()  // Calls the default constructor{ this.Id = id;}
Upcasting and Downcasting -- (theoretical concept)
-Upcasting: conversion from a derived class to a base class.
-Downcasting: conversion from a base class to a derived class.
-All objects can be implicitly converted to a base class reference. 
Shape shape = circle; // Upcasting
-Downcasting requires a cast.
Circle circle = (Circle)shape;// Downcasting
-Casting can throw an exception if the conversion is not successful. We can use the as keyword to prevent this. 
If conversion is not successful, null is returned. 
Circle circle = shape as Circle;
if (circle != null) ...
-We can also use the is keyword:
if (shape is Circle){    var circle = (Circle) shape;.....}
Boxing and Unboxing
-C# types are divided into two categories: value types and reference types.
-Value types (eg int, char, bool, all primitive types and struct) are stored in the stack. They have a short life time and as soon as they go out of scope are removed from memory.
-Reference types (eg all classes) are stored in the heap. 
-Every object can be implicitly cast to a base class reference. 
-The object class is the parent of all classes in .NET Framework.
-So a value type instance (eg int) can be implicitly cast to an object reference. 
-Boxing happens when a value type instance is converted to an object reference. 
-Unboxing is the opposite: when an object reference is converted to a value type.
-Both boxing and unboxing come with a performance penalty. This is not noticeable when dealing with small number of objects. 
But if you’re dealing with several thousands or tens of thousands of objects, it’s better to avoid it. 
obj = 1; // Boxingobject 
i = (int)obj;// Unboxingint 
POLYMORPHISM//Method Overriding
-Method overriding means changing the implementation of an inherited method.
-If a declare a method as virtual in the base class, we can override it in a derived class.
public class Shape{  
public virtual Draw() { // Default implementation for all derived classes   }}
public class Circle : Shape{public override Draw() { // Changed implementation    }}
-This technique allows us to achieve polymorphism. 
Polymorphism is a great object-oriented technique that allows use get rid of long procedural switch statements (or conditionals)
Abstract Classes and Members
-Abstract modifier states that a class or a member misses implementation. We use abstract members when it doesn’t make sense to implement them in a base class. For example, the concept of drawing a shape is too abstract. We don’t know how to draw a shape. This needs to be implemented in the derived classes.
-When a class member is declared as abstract, that class needs to be declared as abstract as well. That means that class is not complete. 
-In derived classes, we need to override the abstract members in the base class.
public abstract class Shape{         // This method doesn’t have a body.     
public abstract Draw();}
public class Circle : Shape{public override Draw(){// Changed implementation}}
-In a derived class, we need to override all abstract members of the base class, otherwise that derived class is going to be abstract too.
-Abstract classes cannot be instantiated.
Sealed Classes and Members
-If applied to a class, prevents derivation from that class.
-If applied to a method, prevents overriding of that method in a derived class.
-The string class is declared as sealed, and that’s why we cannot inherit from it.
public sealed class String{     }
INTERFACES Introduction
-An interface is a language construct that is similar to a class (in terms of syntax) but is fundamentally different.
-An interface is simply a declaration of the capabilities (or services) that a class should provide. 
public interface ITaxCalculator{       
int Calculate();}
-This interface states a class that wants to play the role of a tax calculator, should provide a method called Calculate() that takes no parameters 
and returns an int. The implementation of this class might look like this:
public class TaxCalculator : ITaxCalculator {      public void Calculate() { ... }}
-So an interface is purely a declaration. Members of an interface do not have implementation. 
-An interface can only declare methods and properties, but not fields (because fields are about implementation detail).
-Members of an interface do not have access modifiers. 
Interfaces help building loosely coupled applications. We reduce the coupling between two classes by putting an interface between them. This way, if one of these classes changes, it will have no impact on the class that is dependent on that (as long as the interface is kept the same). Interfaces and Testability
-Unit testing is part of the automated practice which helps improve the quality of our code. With automated testing, we write code to test our own code. This helps catching bugs early on as we change the code. 
-In order to unit test a class, we need to isolate it. This means: we need to assume that every other class in our application is working properly and see if the class under test is working as expected.
-A class that has tight dependencies to other classes cannot be isolated. 
-To solve this problem, we use an interface. Here is an example:
public class OrderProcessor{  private IShippingCalculator _calculator;       
public Customer(IShippingCalculator calculator)       {        _calculator = calculator;       }       ...}
-So here, OrderProcessor is not dependent on the ShippingCalculator class. It’s only dependent on an interface (IShippingCalculator). 
If we change the code inside the ShippingCalculator (eg add a new method or change the method implementations) it will have no impact on OrderProcessor (as long as the interface is kept the same)
Interfaces & accessibility
-We can use interfaces to change our application’s behaviour by “extending” its code (rather than changing the existing code).
-If a class is dependent on an interface, we can supply a different implementation of that interface at runtime. This way, the behaviour of the application changes without any impact on that class. 
-For example, let’s assume our DbMigrator class is dependent on an ILoggerinterface. At runtime, we can supply a ConsoleLogger to log the messages on the console. Later, we may decide to log the messages in a file (or a database). 
We can simply create a new class that implements the ILogger interface and inject it into DbMigrator. Interfaces and Inheritance-One of the common misconceptions about interfaces is that they are used to implement multiple inheritance in C#. This is fundamentally wrong, yet many books and videos make such a false claim. -With inheritance, we write code once and re-use it without the need to type all that code again. 
-With interfaces, we simply declare the members the implementing class should contain. Then we need to type all that declaration along with the actual implementation in that class. So, code is not inherited,even the declaration of the members!
