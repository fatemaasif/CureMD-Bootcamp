namespace _17
{
    internal class Program
    { //Write a program that sorts an array. (take input as random numbers)
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a list of numbers to sort them: ");
            string input = Console.ReadLine();
            string[] numbers = input.Split(' ');
            int[] array = Array.ConvertAll(numbers, int.Parse); //converts string array to num array
            int temp;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i+1; j <array.Length ; j++)
                {
                    if (array[i] > array[j])
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
            Console.WriteLine("The sorted array is: ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]+" ");
            }

        }
    }
}