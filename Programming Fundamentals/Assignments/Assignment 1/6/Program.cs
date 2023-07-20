using System;

namespace _6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number to obtain a sum of numbers from 1 to that number: ");
            int x = Convert.ToInt32(Console.ReadLine());
            int sum=1;
            for (int i = 2; i <= x; i++)
            {
                sum += i;
            }
            Console.WriteLine(sum);
        }
    }
}
