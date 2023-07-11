namespace _12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a word or phrase to check if it's a palindrome: ");
            string text = Console.ReadLine();
            text = text.Replace(" ", ""); //remove spaces
            string reversed = "";
            for (int i = text.Length-1; i >= 0; i--)
            {
                reversed = reversed + text[i];
            }
            string result = reversed == text ? "It is a palindrome!" : "It is not a palindrome!";
            Console.WriteLine(result);
        }
    }
}