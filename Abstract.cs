/*Abstract Method*/

//Square.cs
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
}

//Shape.cs
using System;

namespace CSharpIntermediate
{
    public abstract class Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Position Position { get; set; }

        public abstract void Draw();

        public void Copy()
        {
            Console.WriteLine("Copy shape into clipboard");
        }
    }
}

//Program.cs
using System.Collections.Generic;
using System;

namespace CSharpIntermediate
{
    public class Rectangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Draw a Rectangle");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var square = new Square();
            square.Draw();

            var rectangle = new Rectangle();
            rectangle.Draw();
        }
    }
}


