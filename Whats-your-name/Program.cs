Console.WriteLine("Ingrese su nombre: ");
string nombre = Console.ReadLine() ?? "Usuario";
Console.WriteLine("Ingrese su edad: ");
int edad = Convert.ToInt32(Console.ReadLine());
if(edad<=13)
{
    Console.WriteLine("Eres un niño.");
}
else if(edad>13 && edad<=17)
{
    Console.WriteLine("Eres un adolescente.");
}
else if(edad>17 && edad<=64)
{
    Console.WriteLine("Eres un adulto.");
}
else
{
    Console.WriteLine("Eres un adulto mayor.");
}

