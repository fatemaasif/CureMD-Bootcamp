namespace _14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a list of numbers seperated by a space: ");
            string[] numbers_str = Console.ReadLine().Split(' '); //splits the numbers into an array of strings
            int[] numbers = Array.ConvertAll(numbers_str, int.Parse); //converts string array into int array
            int largest = numbers[0];
            int smallest = numbers[0];
            foreach (int i in numbers)
            {
                if (i > largest)
                { 
                    largest = i; 
                }
                if (i < smallest)
                {
                    smallest = i;
                }
            }
            
            Console.WriteLine("Largest number = " + largest);
            Console.WriteLine("Smallest number = " + smallest);
        }
    }
}