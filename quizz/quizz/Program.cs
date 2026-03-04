// 1 C DOUBLE
// 2 MUNDOC#
// 3 C   
// 4 B
//5 imprime 
//          1 
//          2
//          LOOP
//6  String lists no necesita llevar corchetes sino llaves. Y sin numero.
//7 dia de semana
//8 El switch nunca termina el codigo se queda sin instruccion que seguir.
//9 b
//10 
namespace quizz
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> nombres = new List<string> { "Ana", "Carlos", "Lu", "Beatriz" };

            foreach (var nombre in nombres)
            {
                if(nombre.Length > 4)
                {
                    Console.WriteLine(nombre);
                }
                // tu código aquí
            }



            Console.WriteLine("Hello, World!");
        }
    }
}