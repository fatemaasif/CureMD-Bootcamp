using System;

namespace _8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number to obtain all prime numbers up till that number: ");
            int x = Convert.ToInt32(Console.ReadLine());
            
            for (int i = 1; i <= x; i++)
            {
                int isprime = 0;
                for (int j = 2; j < i; j++)
                {
                    if (i%j==0)
                    {
                        isprime = 1;
                        break;                        
                    }
                  
                }
                if (isprime == 0)
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
