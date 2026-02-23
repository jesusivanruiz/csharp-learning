namespace nameValidation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool keepAddingNames = true;
            List<string> usernames = new List<string>();
            while (keepAddingNames)
            {
                Console.WriteLine("Enter your name:");
                string name = Console.ReadLine() ?? "";
                string nameTrimmed = name.Trim();
                if (nameTrimmed.Length == 0)
             {
                Console.WriteLine("Invalid name, can not be empty. Please enter a valid name.");
                }
             else if (nameTrimmed.Length < 4)
                {
                Console.WriteLine("Invalid name. Name must be at least 4 characters long.");
                }
                else if (nameTrimmed.Contains(' '))
                {
                Console.WriteLine("Invalid name. Name must not contain spaces.");
                }
                else if (nameTrimmed == "salir")
                {   
                Console.WriteLine("Exiting the program. Goodbye!");
                keepAddingNames = false;
                }
                else if (nameTrimmed.Length > 20)
                {
                Console.WriteLine("Invalid name. Name must be no more than 20 characters long.");
              }
              else
                {
                    usernames.Add(nameTrimmed);
                    Console.WriteLine($"Name:'{nameTrimmed}' added successfully.");
                  
                }   
            }
                Console.WriteLine($"Usernames registered \n:");
                int index = 0;
                foreach (string username in usernames)
                {
                    Console.WriteLine($"{index + 1}.- Username: {username}");
                    index++;
                }
        }
    }
}    