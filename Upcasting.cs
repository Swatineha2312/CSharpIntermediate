/* Upcasting Demo*/

//Shape.cs

using System;

namespace CSharpIntermediate
{
    class Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public void Draw()
        {

        }
    }
}


//Text.cs

using System;

namespace CSharpIntermediate
{
    class Text : Shape
    {
        public int FontSize { get; set; }
        public int FontName { get; set; }        
    }
}


//Main class Program.cs

using System;

namespace CSharpIntermediate
{
    class Program
    {
        static void Main(string[] args)
        {
            Text text = new Text();
            Shape shape = text;

            text.Width = 200;
            shape.Width = 100; //shape and text object refering to smae object so o/p is 100 here         

            Console.WriteLine(text.Width);
        }
    }
}

