namespace _16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter string to be reversed");
            string text = Console.ReadLine();
            string reversed="";
            for (int i = text.Length-1; i >= 0; i--)
            {
                reversed = reversed + text[i];
            }
            Console.WriteLine("The reversed string is: " + reversed);
        }
    }
}