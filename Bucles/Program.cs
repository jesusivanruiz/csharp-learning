int attempts = 1;
while (attempts <= 3)
{    Console.Write($"Attempt: {attempts} \n");
    attempts++; 
}
    Console.WriteLine("End of loop.");

List<string> languages = new List<string> { "C#", "Python", "JavaScript" };

  foreach (string language in languages)
  {
      Console.WriteLine($"Language: {language}");
  }
