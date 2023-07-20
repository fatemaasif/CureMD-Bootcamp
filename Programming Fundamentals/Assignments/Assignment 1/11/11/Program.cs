using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a list of 5 numbers to search from seperated by a space: ");
            string[] numbers_str = Console.ReadLine().Split(' ');
            int[] numbers = Array.ConvertAll(numbers_str, int.Parse);
            Console.WriteLine("Enter a number to search: ");
            int x = Convert.ToInt32(Console.ReadLine());
            bool flag = false; //assumes number not found until it is
            foreach (int num in numbers)
            {
                if (num == x)
                {
                    flag = true;
                }
            }
            if (flag == true)
            {
                Console.WriteLine("Number found!");
            }
            else
            {
                Console.WriteLine("Number not found!");
            }
            Console.ReadKey();

        }
    }
}
