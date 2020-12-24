//Polymorphism explanation
//Method Overloading

//So we have a program of Shape whose methods would be inherited by other functions as Circle, Rectangle etc and 
//simple program to perform this action is as follows:

//Shape.cs
namespace CSharpIntermediate
{
    class Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Position Position { get; set; }
        public ShapeTypes Type { get; set; }      
    }
}

//Position.cs
namespace CSharpIntermediate
{
    class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}

//ShapeTypes.cs
namespace CSharpIntermediate
{
    public enum ShapeTypes
    {
        Square,
        Rectangle
    }
}

//Canvas.cs
using System;
using System.Collections.Generic;

namespace CSharpIntermediate
{
    class Canvas
    {
        public void DrawShapes(List<Shape> shapes)
        {
            foreach (var shape in shapes)
            {
                switch (shape.Type)
                {
                    case ShapeTypes.Square:
                        Console.WriteLine("Draw a Square");
                        break;
                    case ShapeTypes.Rectangle:
                        Console.WriteLine("Draw a rectangle");
                        break;
                }
            }
        }
    }
}

//Program.cs(Main program)
using System.Collections.Generic;

namespace CSharpIntermediate
{
    class Program
    {
        static void Main(string[] args)
        {
            var shapes = new List<Shape>();
            shapes.Add(new Shape { Width = 100, Height = 100, Type = ShapeTypes.Square });
            shapes.Add(new Shape { Width = 100, Height = 100, Type = ShapeTypes.Rectangle });

            var canvas = new Canvas();
            canvas.DrawShapes(shapes);
        }
    }
}

//now if we need to add further more shape types lets say triangle,pentagon etc. then we need to do changes as:

//ShapeTypes.cs
namespace CSharpIntermediate
{
    public enum ShapeTypes
    {
        Square,
        Rectangle,
        Triangle
    }
}

//Canvas.cs
using System;
using System.Collections.Generic;
namespace CSharpIntermediate
{
    class Canvas
    {
        public void DrawShapes(List<Shape> shapes)
        {
            foreach (var shape in shapes)
            {
                switch (shape.Type)
                {
                    case ShapeTypes.Square:
                        Console.WriteLine("Draw a Square");
                        break;
                    case ShapeTypes.Rectangle:
                        Console.WriteLine("Draw a rectangle");
                        break;
                    case ShapeTypes.Triangle:
                        Console.WriteLine("Draw a triangle");
                        break;
                }
            }
        }
    }
}

/*problem is every time we have to look every class and do alterations and also it makes the Canvas code very bulky.
everytime we make changes every time it needs to be recompiled which increases the load on compiler 
and there is loads of tight coupling here.
one reason of this issue is also the Shape class has only properties. Doesnt have any methods/behaviours 
and that is present in canvas class.There is no encapsulation.
*/
//for this we need toget rid of enum and have deleted the enum class nmaed ShapeTypes.cs
//and adding polymorphics properties to other classes as follows, Only Position class remains the same:

//Shape.cs
using System;

namespace CSharpIntermediate
{
    public class Square : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Draw a Square");
        }
    }
    public class Rectangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Draw a rectangle");
        }
    }
    public class Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Position Position { get; set; }

        public virtual void Draw()
        {

        }
    }
}

//Canvas.cs
using System.Collections.Generic;

namespace CSharpIntermediate
{
    class Canvas
    {
        public void DrawShapes(List<Shape> shapes)
        {
            foreach (var shape in shapes)
            {
                shape.Draw();//here exists the polymorphism as the draw method is called for Square in one object 
                             //for Rectangle and other object//having many forms depending on objects we have at run time
            }
        }
    }
}

//Program.cs
using System.Collections.Generic;

namespace CSharpIntermediate
{
    class Program
    {
        static void Main(string[] args)
        {
            var shapes = new List<Shape>();
            shapes.Add(new Square());
            shapes.Add(new Rectangle());

            var canvas = new Canvas();
            canvas.DrawShapes(shapes);
        }
    }
}

/*now if we nee dto add the other shape type we need not to change properties of different classes and its addition
will also not effect the other classes as we just need to add a function*/

//Shape.cs

using System;

namespace CSharpIntermediate
{
    public class Square : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Draw a Square");
        }
    }
    public class Rectangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Draw a rectangle");
        }
    }
    public class Triangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Draw a triangle");
        }
    }
    public class Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Position Position { get; set; }

        public virtual void Draw()
        {

        }
    }
}
//This doesnt effect Shape,Square,Triangle,Canvas class etc. and it is loosely coupled app.