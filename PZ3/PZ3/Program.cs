using static PZ3.Expression;

namespace PZ3;

internal class Program
{
    static void Main(string[] args)
    {
        var x = new Variable("x");
        var y = new Variable("y");
        var c = new Constant(3);
        Expression expr1 = (x - 4) * (3 * x + y * y) / 5;
        Expression expr2 = (5 - 3 * c) * Sqrt(16 + c * c);

        Console.WriteLine(expr1);
        Console.WriteLine(expr1.Compute(new Dictionary<string, double> { ["x"] = 1, ["y"] = 2 }));
        Console.WriteLine(expr2);
        Console.WriteLine(expr2.Compute(new Dictionary<string, double> { ["x"] = 1, ["y"] = 2 }));
        Console.ReadLine();
    }
}