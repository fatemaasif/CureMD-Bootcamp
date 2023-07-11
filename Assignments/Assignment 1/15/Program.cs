using System;

namespace _15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the height of the right angle triangle: ");
            int height = int.Parse(Console.ReadLine());
            for (int i = 0; i <= height; i++)
            {
                for (int j = height-1; j >= i; j--)
                {
                    Console.Write(" ");
                }
                for (int j = 1; j <= 2*i-1; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}