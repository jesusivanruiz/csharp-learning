# Referencia Rápida — C#
> Cosas que se olvidan fácil o que no son intuitivas.
> No es un tutorial — es para cuando tu memoria falle.

---

## Null y el operador ??

`Console.ReadLine()` puede devolver `null`. C# moderno te obliga a manejarlo.

```csharp
// Mal — el compilador se queja
string nombre = Console.ReadLine();

// Bien — si es null, usa "desconocido"
string nombre = Console.ReadLine() ?? "desconocido";
```

**`??` significa:** "si lo de la izquierda es null, usa lo de la derecha".
Lo verás constantemente en C#.

---

## String interpolation

```csharp
// Con concatenación — funciona pero es incómodo
Console.WriteLine("Hola " + nombre + " tienes " + edad + " años");

// Con interpolación — más limpio
Console.WriteLine($"Hola {nombre} tienes {edad} años");
```

**Regla:** pon `$` antes de las comillas. Todo lo que esté entre `{}` se evalúa como código.

---

## Convertir string a número

`Console.ReadLine()` siempre devuelve texto. Para usarlo como número hay que convertirlo.

```csharp
// Parse — directo, explota si el texto no es un número válido
int edad = int.Parse("25");       // ok
int edad = int.Parse("abc");      // EXCEPCIÓN — el programa muere

// Convert — hace lo mismo que Parse, misma fragilidad
int edad = Convert.ToInt32(Console.ReadLine());

// TryParse — nunca explota, verifica antes de convertir
if (int.TryParse(Console.ReadLine(), out int numero))
{
    // entró aquí: la conversión funcionó, numero tiene el valor
}
else
{
    // entró aquí: el texto no era un número, numero vale 0
}
```

**Cuándo usar cada uno:**
- `int.Parse` / `Convert.ToInt32` — cuando los datos vienen de tu propio código y sabes que son válidos
- `int.TryParse` — siempre que el dato venga del usuario (consola, formulario, API)

**La palabra `out`:** le pasas una variable vacía al método y él la llena por dentro. Es un parámetro de salida.

---

## Tipos de datos — cuándo usar cuál

```csharp
string nombre = "Juan";        // texto
int edad = 25;                 // número entero
double temperatura = 36.6;     // decimal (cálculos, física, etc.)
decimal precio = 19.99m;       // decimal EXACTO — siempre para dinero (la m es obligatoria)
bool activo = true;            // verdadero/falso
char inicial = 'J';            // un solo carácter (comillas simples)
```

**Trampa frecuente:** `decimal` requiere `m` al final del número. Sin ella C# lo trata como `double`.
```csharp
decimal mal  = 19.99;   // error
decimal bien = 19.99m;  // correcto
```

---

## Estructura completa de un programa

```csharp
namespace MiProyecto;       // contenedor (el "universo")

class Program               // el molde
{
    static void Main(string[] args)   // punto de entrada — el compilador arranca aquí
    {
        // tu código va aquí
    }
}
```

**Qué es cada cosa:**
- `namespace` — agrupa clases, evita conflictos de nombres
- `class` — el molde. Por sí sola no hace nada, de ella se crean objetos
- `static void Main` — método de entrada. `void` = no devuelve nada. `static` = pertenece a la clase, no a un objeto

---

## Git — flujo básico diario

```bash
git status                        # ver qué cambió — úsalo siempre primero
git add .                         # preparar todos los cambios
git commit -m "mensaje claro"     # guardar en el historial
git log --oneline                 # ver el historial resumido
```

**Para proyectos .NET, siempre al iniciar:**
```bash
git init
dotnet new gitignore              # ignora bin/ obj/ y otros archivos generados
git add .
git commit -m "Commit inicial"
```

---

## Control de flujo — if / else

```csharp
if (edad >= 18)
{
    Console.WriteLine("Mayor de edad");
}
else if (edad >= 13)
{
    Console.WriteLine("Adolescente");
}
else
{
    Console.WriteLine("Niño");
}
```

**Trampa frecuente:** en cadenas `else if`, cada bloque ya descarta las condiciones anteriores. No las repitas:

```csharp
// Redundante — si llegó aquí ya sabemos que edad >= 13
else if (edad >= 13 && edad < 18)

// Correcto — la condición anterior ya fue descartada
else if (edad < 18)
```

**Operadores lógicos:**
```csharp
&&   // AND — ambas condiciones deben ser true
||   // OR  — al menos una debe ser true
!    // NOT — invierte el valor
```

---

## Bucles

**`for`** — cuando sabes cuántas veces repetir:
```csharp
for (int i = 1; i <= 10; i++)   // del 1 al 10 inclusive
{
    Console.WriteLine(i);
}
```
Tres partes: `valor inicial` | `condición para continuar` | `qué hacer al final de cada vuelta`

**Trampa frecuente:** `i < numero` excluye el último valor. `i <= numero` lo incluye.

```csharp
for (int i = 1; i < 5; i++)    // imprime 1, 2, 3, 4  — el 5 no aparece
for (int i = 1; i <= 5; i++)   // imprime 1, 2, 3, 4, 5
```

**`while`** — cuando no sabes cuántas veces, solo la condición para parar:
```csharp
while (intentos < 3)
{
    intentos++;   // ojo: sin esto el bucle es infinito
}
```

**`foreach`** — para recorrer colecciones elemento por elemento:
```csharp
foreach (string language in languages)
{
    Console.WriteLine(language);
}
```
Léelo como: "por cada `language` que esté en `languages`, haz esto".
`language` es una variable temporal que toma el valor de cada elemento por vuelta.
Convención: usar el singular del nombre de la lista.

**Cuándo usar for vs foreach:**
- Necesitas el número de vuelta → `for`
- Solo necesitas los elementos → `foreach`

---

## List\<T\> — listas dinámicas

La colección que más usarás en C#.

```csharp
List<string> names = new List<string> { "Ana", "Luis", "María" };
List<int>    ages  = new List<int> { 25, 30, 18 };
```

`<T>` define el tipo de elementos que acepta. Si intentas meter un tipo distinto, el compilador te detiene.

```csharp
// Operaciones básicas
names.Add("Juan");           // agregar al final
names.Remove("Ana");         // eliminar por valor
names[0];                    // acceder por índice (empieza en 0)
names.Count;                 // cantidad de elementos
names.Contains("Luis");      // true/false — ¿existe el valor?
```

---

## switch — elegir entre muchos casos

Alternativa a `if/else` cuando comparas una variable contra valores concretos. Más limpio cuando hay 3+ opciones.

```csharp
int dia = 3;

switch (dia)
{
    case 1:
        Console.WriteLine("Lunes");
        break;
    case 2:
        Console.WriteLine("Martes");
        break;
    case 3:
        Console.WriteLine("Miércoles");
        break;
    default:
        Console.WriteLine("Otro día");
        break;
}
```

**`default`** es el equivalente al `else` — se ejecuta si ningún `case` coincide.
**`break`** es obligatorio al final de cada `case` — sin él el compilador se queja.

---

## switch expression — versión moderna (C# 8+)

Más compacta. Devuelve un valor directamente.

```csharp
string resultado = dia switch
{
    1 => "Lunes",
    2 => "Martes",
    3 => "Miércoles",
    _ => "Otro día"    // _ es el default en esta sintaxis
};
Console.WriteLine(resultado);
```

**Cuándo usar cuál:**
- `switch` clásico → cuando ejecutas varias líneas de código por caso
- `switch` expression → cuando solo necesitas asignar un valor según el caso

---

## do-while — ejecutar al menos una vez

La diferencia con `while`: el código se ejecuta **primero** y la condición se evalúa **después**.
Garantiza que el bloque corre al menos una vez.

```csharp
int intentos = 0;

do
{
    Console.WriteLine("Introduce un número positivo:");
    int numero = int.Parse(Console.ReadLine() ?? "0");
    intentos++;
} while (intentos < 3);
```

**Cuándo usarlo:** cuando necesitas pedir un dato al usuario y validarlo — siempre tienes que preguntar al menos una vez.

---

## break y continue — controlar el flujo dentro de bucles

**`break`** — sale del bucle completamente:
```csharp
for (int i = 1; i <= 10; i++)
{
    if (i == 5)
        break;               // para en el 5, nunca llega al 6

    Console.WriteLine(i);    // imprime 1, 2, 3, 4
}
```

**`continue`** — salta la vuelta actual y pasa a la siguiente:
```csharp
for (int i = 1; i <= 10; i++)
{
    if (i == 5)
        continue;            // salta el 5, sigue con el 6

    Console.WriteLine(i);    // imprime 1, 2, 3, 4, 6, 7, 8, 9, 10
}
```

**Regla simple:**
- `break` → "para todo"
- `continue` → "salta este, sigue con el siguiente"

---

## List\<T\> — listas dinámicas

La colección que más usarás en C#.

```csharp
List<string> names = new List<string> { "Ana", "Luis", "María" };
List<int>    ages  = new List<int> { 25, 30, 18 };
```

`<T>` define el tipo de elementos que acepta. Si intentas meter un tipo distinto, el compilador te detiene.

```csharp
// Operaciones básicas
names.Add("Juan");           // agregar al final
names.Remove("Ana");         // eliminar por valor
names[0];                    // acceder por índice (empieza en 0)
names.Count;                 // cantidad de elementos
names.Contains("Luis");      // true/false — ¿existe el valor?
```

---
*Última actualización: 2026-02-22*
