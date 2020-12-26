# CSharpIntermediate

CLASSESIntroduction
-Classes are building blocks of software applications. 
-A class encapsulates data (stored in fields) and behaviour (defined by methods).
public class Customer 
{
// Field      
public string Name; 
// Method       
public void Promote()        
 {      
 }
}
-An object is an instance of a class. We can create an object using the new operator. 
Customer customer = new Customer();
// Or
var customer = new Customer();

Constructors
-A constructor is a method that is called when an instance of a class is created.
-We use constructors to put an object in an early state.
-As a best practice, define a constructor only when an object “needs” to be initialised or it won’t be able to do its job.
-Constructors do not have a return type, not even void, and they should have the exact same name as the class. 
-A quick way to create a constructor: type ctor and press tab. This is a code snippet.
-Constructors can be overloaded. Overloading means creating a method with the same name and different signatures. 
-Signature of a method consists of the number, type and order of its parameters.
-We can pass control from one constructor to the other by using the this keyword.
public class Customer 
{       
public int Id;       
public string Name;       
public List<Order> Orders;      
// Default or parameterless constructor       
public Customer()       
  {           
  // Orders has to be initialized here, otherwise it             
  // will be a null reference. As a best practice,             
  // anytime your class contains a list, always            
  // initialize the list.             
  Orders = new List<Order>();       
  }       
  public Customer(int id)          
  : this()  // Calls the default constructor     
  {            
  this.Id = id;
  }
}

Upcasting and Downcasting -- (theoretical concept)
-Upcasting: conversion from a derived class to a base class.
-Downcasting: conversion from a base class to a derived class.
-All objects can be implicitly converted to a base class reference. 

// Upcasting
Shape shape = circle; 

-Downcasting requires a cast.
// Downcasting
Circle circle = (Circle)shape;

-Casting can throw an exception if the conversion is not successful. We can use the as keyword to prevent this. 
If conversion is not successful, null is returned. 

Circle circle = shape as Circle;
if (circle != null) ...

-We can also use the is keyword:
if (shape is Circle)
{    
var circle = (Circle) shape;
.....
}

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

// Boxingobject 
obj = 1; 
// Unboxingint 
i = (int)obj;

POLYMORPHISM
Method Overriding
-Method overriding means changing the implementation of an inherited method.
-If a declare a method as virtual in the base class, we can override it in a derived class.
public class Shape
{  
 public virtual Draw()    
  {        
   // Default implementation for all derived classes   
  }
}
public class Circle : Shape
{          
 public override Draw()    
 {         
 // Changed implementation    
 }
}
-This technique allows us to achieve polymorphism. 
Polymorphism is a great object-oriented technique that allows use get rid of long procedural switch statements (or conditionals)

Abstract Classes and Members
-Abstract modifier states that a class or a member misses implementation. We use abstract members when it doesn’t make sense to implement them in a base class. For example, the concept of drawing a shape is too abstract. We don’t know how to draw a shape. This needs to be implemented in the derived classes.
-When a class member is declared as abstract, that class needs to be declared as abstract as well. That means that class is not complete. 
-In derived classes, we need to override the abstract members in the base class.

public abstract class Shape
{         
// This method doesn’t have a body.     
public abstract Draw();
}
public class Circle : Shape
{          
 public override Draw()
 {      
 // Changed implementation    
 }
}
-In a derived class, we need to override all abstract members of the base class, otherwise that derived class is going to be abstract too.
-Abstract classes cannot be instantiated

Sealed Classes and Members
-If applied to a class, prevents derivation from that class.
-If applied to a method, prevents overriding of that method in a derived class.

-The string class is declared as sealed, and that’s why we cannot inherit from it.
public sealed class String
 {     
 }
