namespace _13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the height of the right angle triangle: ");
            int height = int.Parse(Console.ReadLine());
            for (int i = 0; i <= height; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }

        }
    }
}