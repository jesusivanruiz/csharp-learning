using System.Globalization;

namespace TestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool numberProgram = true;
            do {
                Console.WriteLine("Enter a number:");
                if (!int.TryParse(Console.ReadLine(), out int number))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    continue;
                }
                Console.WriteLine($"You entered: {number}");
                numberProgram = false;

            } while (numberProgram);
        }
    }
}