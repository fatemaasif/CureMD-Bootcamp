using System;

namespace _4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number to obtain square: "); 
            int x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Square = " + Math.Pow(x,2));
        }
    }
}
