using System;

namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter first number: ");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter second number: ");
            int y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Sum: " + (x + y));
        }
    }
}
