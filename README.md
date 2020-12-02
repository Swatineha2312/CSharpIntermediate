# CSharpIntermediate

Upcasting and Downcasting -- theoretical concept
-Upcasting: conversion from a derived class to a base class
-Downcasting: conversion from a base class to a derived class
-All objects can be implicitly converted to a base class reference. 

// Upcasting
Shape shape = circle; 

-Downcasting requires a cast.

// Downcasting
Circle circle = (Circle)shape;

-Casting can throw an exception if the conversion is not successful. We can use the as keyword to prevent this. If conversion is not successful, null is returned. 

Circle circle = shape as Circle;
if (circle != null) ...

-We can also use the is keyword:

if (shape is Circle)
{    
var circle = (Circle) shape;
.....
}
