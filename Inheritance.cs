/*Inheritance simple e.g.*/

//======Presentation Object=========

using System;

namespace CSharpIntermediate
{
    class PresentationObject
    {
        public int width { get; set; }
        public int height { get; set; }

        public void Copy()
        {
            Console.WriteLine("Object copied");
        }
        public void Duplicate()
        {
            Console.WriteLine("Object duplicated");
        }
    }
}

//=======Text.cs=========

using System;

namespace CSharpIntermediate
{
    class Text : PresentationObject
    {
        public int FontSize { get; set; }
        public int FontName { get; set; }

        public void AddHyperlink(string url)
        {
            Console.WriteLine("Added url" + url);
        }
    }
}


//======Program.cs=======

using System;

namespace CSharpIntermediate
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = new Text();
            text.height = 100;
            text.Copy();
        }
    }
}
