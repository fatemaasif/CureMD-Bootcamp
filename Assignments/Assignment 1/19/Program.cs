namespace _19
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number of rows: ");
            int rows = int.Parse(Console.ReadLine());
            for (int i = 1; i <= rows; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(j);
                }
                Console.WriteLine();
            }
        }
    }
}