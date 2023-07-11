using System.Data.SqlTypes;
using System.Globalization;

namespace _18
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number to check if it is a perfect number: ");
            int number = int.Parse(Console.ReadLine());
            string divisors = "";
            for (int i = 1; i < number; i++)
            {
                if (number%i==0)
                {
                    divisors = divisors + i + ' ';
                }
            }
            divisors = divisors.Trim(); 
            string[] divstr = divisors.Split(' ');
            int[] divisorarr = Array.ConvertAll(divstr, int.Parse); //split into array of string and convert to int
            int sum = 0;
            Console.Write("The divisors are: ");
            foreach (int divisor in divisorarr) 
            {
                Console.Write(divisor + " ");   
                sum = sum + divisor;
            }
            Console.WriteLine();
            string print = sum == number ? $"Sum: {sum} It's a perfect number" : $"Sum: {sum} It's not a perfect number";
            Console.WriteLine(print);   
        }
    }
}