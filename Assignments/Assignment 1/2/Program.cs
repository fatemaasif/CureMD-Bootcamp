using System;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your first name: ");
            string username = Console.ReadLine();
            string usernameCapitalized = username[0].ToString().ToUpper() + username.Substring(1);
            Console.WriteLine($"Hello, {usernameCapitalized}");
        }
    }
}
