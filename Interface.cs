/*Interfaces
Another way to achieve abstraction in C#, is with interfaces.
An interface is a completely "abstract class", which can only contain abstract methods and properties (with empty bodies)*/
//FileInfo.cs
using System;
namespace CSharpIntermediate
{
    interface IFile
    {
        void Read();
        void Write(string text);
    }
    class FileInfo : IFile
    {
        public void Read()
        {
            Console.WriteLine("read file");
        }
        public void Write(string text)
        {
            Console.WriteLine("write file"+text);
        }
    }
}
//Program.cs
using System;
namespace CSharpIntermediate
{
    class Program
    {
        static void Main(string[] args)
        {
            IFile file1 = new FileInfo();
            FileInfo file2 = new FileInfo();

            file1.Read();
            file1.Write("content");

            file2.Read();
            file2.Write("content");
        }
    }
}
/*Notes on Interfaces:
    -Like abstract classes, interfaces cannot be used to create objects (in the example above, it is not possible to create an "IAnimal" object in the Program class)
    -Interface methods do not have a body - the body is provided by the "implement" class
    -On implementation of an interface, you must override all of its methods
    -Interfaces can contain properties and methods, but not fields/variables
    -Interface members are by default abstract and public
    -An interface cannot contain a constructor (as it cannot be used to create objects)
Why And When To Use Interfaces?
1) To achieve security - hide certain details and only show the important details of an object (interface).
2) C# does not support "multiple inheritance" (a class can only inherit from one base class). However, it can be achieved 
with interfaces, because the class can implement multiple interfaces. Note: To implement multiple interfaces, 
separate them with a comma. If you dont make methods public then it would throw compile time error. Below e.g is demonstration*/
//Ifile.cs
//Multiple Interface e.g.
using System;
namespace CSharpIntermediate
{
    interface IFile
    {
        void Read();
        void Write(string text);
    }
    interface ISearch
    {
         void Search();
    }
    class FileInfo : IFile, ISearch //also her on IFile there will be a compile time error as its methods are not public
    {
        void Read()
        {
            Console.WriteLine("read file");
        }
        void Write(string text)
        {
            Console.WriteLine("write file" + text);
        }
        public void Search()
        {
            Console.WriteLine("search");
        }
    }
}
//Program.cs
using System;

namespace CSharpIntermediate
{
    class Program
    {
        static void Main(string[] args)
        {
            IFile file1 = new FileInfo();
            FileInfo file2 = new FileInfo();

            file1.Read();
            file1.Write("content");
            file1.Search();//compile error

            file2.Read();//compile error
            file2.Write("content");//compile error
            file2.Search();
        }
    }
}







