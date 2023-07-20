using System;

namespace _9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number to obtain its factorial: ");
            int x = Convert.ToInt32(Console.ReadLine());
            int result=1;
            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }
            Console.WriteLine("Result = " + result);
        }
    }
}
