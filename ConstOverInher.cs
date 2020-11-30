/*Constructor over inheritance*/

//Vehicle.cs

using System;

namespace CSharpIntermediate
{
    class Vehicle
    {
        private readonly string _registerationNumber;

        //public Vehicle()
        //{
        //    Console.WriteLine("Vehicle is being initialized");
        //}

        public Vehicle(string registerationNumber)
        {
            _registerationNumber = registerationNumber;
            Console.WriteLine("vehicle is initialised {0}",registerationNumber);
        }
    }
}


//Car.cs

using System;

namespace CSharpIntermediate
{
    class Car : Vehicle
    {
        public Car(string registerationNumber)
            : base(registerationNumber)
        {
            Console.WriteLine("Car is initialized. {0}", registerationNumber);
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
            var Car = new Car("x12");

        }
    }
}
