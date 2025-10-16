using Humanizer;
using System.Diagnostics;

// See https://aka.ms/new-console-template for more information

static void HumanizeQuantities()
{
    Console.WriteLine("case".ToQuantity(0));
    Console.WriteLine("case".ToQuantity(1));
    Console.WriteLine("case".ToQuantity(5));
}
static void HumanizeDates()
{
    Console.WriteLine(DateTime.UtcNow.AddHours(-24).Humanize());
    Console.WriteLine(DateTime.UtcNow.AddHours(-2).Humanize());
    Console.WriteLine(TimeSpan.FromDays(1).Humanize());
    Console.WriteLine(TimeSpan.FromDays(16).Humanize());
}

Console.WriteLine("Quantities:");
HumanizeQuantities();

Console.WriteLine("\nDate/Time Manipulation:");
HumanizeDates();


Console.WriteLine("Fibonacci Calculator results:");
int result = Fibonacci(5);
Console.WriteLine(result);
Debug.WriteLine($"Entering {nameof(Fibonacci)} method");

static int Fibonacci(int n)
{
    int n1 = 0;
    int n2 = 1;
    int sum;
    Debug.WriteLine($"We are looking for the {n}th number");

    for (int i = 2; i < n; i++)
    {
        sum = n1 + n2;
        n1 = n2;
        n2 = sum;
        Debug.WriteLineIf(sum == 4, $"sum is 4, n1 is {n1}, n2 is {n2}");
    }

    Debug.Assert(n2 == 5, "No devuelve 5....");
    return n == 0 ? n1 : n2;
}