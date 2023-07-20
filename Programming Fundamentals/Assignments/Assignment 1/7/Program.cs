using System;

namespace _7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number to obtain its multiplication table: ");
            int x = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <=12; i++)
            {
                Console.WriteLine(x + " x " + i + " = " + (x * i));
            }
        }
    }
}
