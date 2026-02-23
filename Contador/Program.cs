 Console.WriteLine("Ingresa un número: ");

  if (int.TryParse(Console.ReadLine(), out int numero))
    {
        if (numero < 0)
        {
        Console.WriteLine("El número no puede ser negativo.");
        }
        else if (numero == 0)
        {
        Console.WriteLine("El número es cero, no se realizarán vueltas."); 
        }
        else if (numero > 100)
        {
             Console.WriteLine("El número es demasiado grande, por favor ingresa un número menor o igual a 100.");
        }
        else
        {
            for (int i = 1; i <= numero; i++)
            {
            Console.WriteLine($"Vuelta número: {i}");
            }
            Console.WriteLine($"¡Vueltas totales: {numero}!");
        } 
    }
    else
         {
            Console.WriteLine("Entrada no válida. Por favor ingresa un número entero.");
            }
