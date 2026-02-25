using System.Collections;

namespace MiniCalculator
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Mini Calculator!");
            Console.WriteLine("Type \"exit\" to quit the calculator at any time.\n");

            bool MiniCalculator = true,
                firstInputValid = true,
                secondInputValid = false,
                thirdInputValid = false;

            string firstInput = "";
            string secondInput = "";
            string thirdInput = "";
            double result = 0,
                num1 = 0,
                num2 = 0;
            List<string> operations = new List<string> { };
            while (MiniCalculator)
            {
                Console.WriteLine("Welcome to the Mini Calculator!");
                Console.WriteLine("OPERATIONS HISTORY");
                if (operations.Count == 0)
                {
                    Console.WriteLine("No operations in history.");
                }
                else
                {
                    foreach (string operationhist in operations)
                    {
                        Console.WriteLine($"{operationhist}");
                    }
                }
                while (firstInputValid)
                {
                    Console.WriteLine("Enter the first number:");
                    firstInput = Console.ReadLine() ?? "NULL";
                    if (double.TryParse(firstInput, out double firstInputParsed))
                    {
                        Console.WriteLine($"MINI-CALCULATOR:\n {firstInputParsed} ");
                        firstInputValid = false;
                        secondInputValid = true;
                        num1 = firstInputParsed;
                    }
                    else
                    {
                        string firsInputSwitched = firstInput switch
                        {
                            "exit" or "quit" => "exit",
                            _ => "InvalidInput",
                            // _ es el default en esta sintaxis
                        };
                        firstInput = firsInputSwitched;
                        if (firstInput == "exit")
                        {
                            MiniCalculator = false;
                            firstInputValid = false;
                            Console.WriteLine("Exiting the Mini Calculator. Goodbye!");
                        }
                        else if (firstInput == "InvalidInput")
                        {
                            Console.WriteLine(
                                "Invalid input. Please enter a valid number or 'exit' to quit."
                            );
                            continue; // Salir del ciclo actual y volver a la condición del while
                        }
                    }
                }
                while (secondInputValid)
                {
                    Console.WriteLine("Enter the operator (+, -, *, /):");
                    secondInput = Console.ReadLine() ?? "NULL";

                    string secondInputSwitched = secondInput switch
                    {
                        "exit" or "quit" => "exit",
                        "+" => "+",
                        "-" => "-",
                        "*" => "*",
                        "/" => "/",
                        _ => "InvalidInput",
                        // _ es el default en esta sintaxis
                    };
                    secondInput = secondInputSwitched;

                    if (secondInput == "exit")
                    {
                        MiniCalculator = false;
                        Console.WriteLine("Exiting the Mini Calculator. Goodbye!");
                        continue; // Salir del ciclo actual y volver a la condición del while
                    }
                    else if (secondInput == "InvalidInput")
                    {
                        Console.WriteLine(
                            $"Invalid operator. Please enter a valid operator (+, -, *, /)."
                        );
                        continue; // Salir del ciclo actual y volver a la condición del while
                    }
                    else
                    {
                        Console.WriteLine($"MINI-CALCULATOR:\n {num1} {secondInput}");
                        secondInputValid = false;
                        thirdInputValid = true; // Salir del ciclo de validación
                    }
                }
                while (thirdInputValid)
                {
                    Console.WriteLine($"Enter the second number:");
                    thirdInput = Console.ReadLine() ?? "NULL";

                    if (double.TryParse(thirdInput, out double thirdInputParsed))
                    {
                        Console.WriteLine($"MINI-CALCULATOR:\n {num1} {secondInput} {thirdInputParsed}");
                        num2 = thirdInputParsed;
                        thirdInputValid = false; // Salir del ciclo de validación
                        switch (secondInput)
                        {
                            case "+":
                                result = num1 + num2;
                                Console.WriteLine($"Result: {result}");
                                break;
                            case "-":
                                result = num1 - num2;
                                Console.WriteLine($"Result: {result}");
                                break;
                            case "*":
                                result = num1 * num2;
                                Console.WriteLine($"Result: {result}");
                                break;
                            case "/":

                                result = num1 / num2;
                                Console.WriteLine($"Result: {result}");

                                continue;
                        }
                    }
                    else
                    {
                        string thirdInputSwitched = thirdInput switch
                        {
                            "exit" or "quit" => "exit",
                            _ => "InvalidInput",
                            // _ es el default en esta sintaxis
                        };
                        thirdInput = thirdInputSwitched;
                        if (thirdInput == "exit")
                        {
                            MiniCalculator = false;
                            break;
                        }
                        else if (thirdInput == "InvalidInput")
                        {
                            Console.WriteLine(
                                "Invalid input. Please enter a valid number or 'exit' to quit."
                            );
                            continue; // Salir del ciclo actual y volver a la condición del while
                        }
                    }

                }
                if (firstInputValid == false && secondInputValid == false && thirdInputValid == false)
                {
                    operations.Add($"{num1} {secondInput} {num2} = {result}");
                    switch (operations.Count)
                    {
                        case 0:
                            Console.WriteLine("No operations in history.");
                            firstInputValid = true;
                            secondInputValid = false;
                            thirdInputValid = false;
                            break;
                        case > 0:
                            firstInputValid = true;
                            secondInputValid = false;
                            thirdInputValid = false;
                            Console.WriteLine("Operation added to history.");
                            Console.WriteLine("============PRESS ENTER TO CONTINUE===============================");
                            Console.ReadLine();
                            break;
                    }

                }
            }
        }
    }
}
