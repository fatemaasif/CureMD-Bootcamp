using System;

namespace _10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number to obtain a Fibonacci sequence up till that number: ");
            int length = Convert.ToInt32(Console.ReadLine());
            int num1 = 0;
            int num2 = 1;
            int result;
            Console.WriteLine(num1);
            Console.WriteLine(num2);
            for (int i = 0; i < length-2; i++)
            {
                result = num1 + num2;
                Console.WriteLine(result);
                num1 = num2;
                num2 = result;
            }
        }
    }
}
