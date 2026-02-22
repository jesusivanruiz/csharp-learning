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
int edad = Convert.ToInt32(Console.ReadLine());

// Alternativa más segura (no revienta si el usuario escribe letras)
int.TryParse(Console.ReadLine(), out int edad);
```

**Cuándo usar cada uno:**
- `Convert.ToInt32` — cuando estás seguro que el usuario va a escribir un número
- `int.TryParse` — cuando no puedes garantizarlo (formularios, APIs, etc.)

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
*Última actualización: 2026-02-22*
