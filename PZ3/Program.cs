using static PZ3.Expression;

namespace PZ3;

internal class Program
{
    static void Main(string[] args)
    {
        var x = new Variable("x");
        var y = new Variable("y");
        var c = new Constant(3);
        var expr1 = (x - 4) * (3 * x + y * y) / 5;
        var expr2 = (5 - 3 * c) * Sqrt(16 + c * c);

        Console.WriteLine(expr1);
        Console.WriteLine(expr1.Compute(new Dictionary<string, double> { ["x"] = 1, ["y"] = 2 }));
        Console.WriteLine(expr2);
        Console.WriteLine(expr2.Compute(new Dictionary<string, double> { ["x"] = 1, ["y"] = 2 }));
        Console.ReadLine();
    }
}
interface IExpr
{
    IEnumerable<string> Variables { get; }
    bool IsConstant { get; }
    bool IsPolynomial { get; }
    int PolynomialDegree { get; }
    double Compute(IReadOnlyDictionary<string, double> variableValues);
}
public abstract class Expression : IExpr
{
    public abstract IEnumerable<string> Variables { get; }
    public abstract bool IsConstant { get; }
    public abstract bool IsPolynomial { get; }
    public abstract int PolynomialDegree { get; }
    public abstract double Compute(IReadOnlyDictionary<string, double> variableValues);

    public static implicit operator Expression(double value) { return new Constant(value); }
    public static implicit operator Expression(string name) { return new Variable(name); }

    public static Expression operator +(Expression left, Expression right) => new Addition(left, right);
    public static Expression operator -(Expression left, Expression right) => new Subtraction(left, right);
    public static Expression operator *(Expression left, Expression right) => new Multiplication(left, right);
    public static Expression operator /(Expression left, Expression right) => new Division(left, right);
    public static Expression Sqrt(Expression operand) => new Sqrt(operand);
    public static Expression Arsinh(Expression operand) => new Arsinh(operand);
    public static Expression Arcosh(Expression operand) => new Arcosh(operand);
    public static Expression Artanh(Expression operand) => new Artanh(operand);
    public static Expression Arcoth(Expression operand) => new Arcoth(operand);
    public static Expression Arcsech(Expression operand) => new Arcsech(operand);
    public static Expression Arccsch(Expression operand) => new Arccsch(operand);
}
public class Constant : Expression
{
    public override IEnumerable<string> Variables => Enumerable.Empty<string>();
    public override bool IsConstant => true;
    public override bool IsPolynomial => true;
    public override int PolynomialDegree => 0;
    public double Value => value;
    protected double value;
    public Constant(double value)
    {
        this.value = value;
    }
    public override double Compute(IReadOnlyDictionary<string, double> variableValues) => Value;
    public override string ToString() => Value.ToString();
}
public class Variable : Expression
{
    public string Name => name;
    protected string name;
    public override IEnumerable<string> Variables => [name];
    public override bool IsConstant => false;
    public override bool IsPolynomial => true;
    public override int PolynomialDegree => 1;
    public override double Compute(IReadOnlyDictionary<string, double> variableValues) => variableValues[Name];
    public Variable(string name)
    {
        this.name = name;
    }

    public override string ToString() => Name;
}
public abstract class BinaryOperation : Expression
{
    public override IEnumerable<string> Variables => FirstOperand.Variables.Union(SecondOperand.Variables);

    public Expression FirstOperand => firstOperand;
    protected Expression firstOperand;
    public Expression SecondOperand => secondOperand;
    protected Expression secondOperand;

    protected BinaryOperation(Expression firstOperand, Expression secondOperand)
    {
        this.firstOperand = firstOperand;
        this.secondOperand = secondOperand;
    }
    public abstract override string ToString();
}
public class Addition : BinaryOperation
{
    public Addition(Expression firstOperand, Expression secondOperand) : base(firstOperand, secondOperand) { }
    public override bool IsConstant => FirstOperand.IsConstant && SecondOperand.IsConstant;
    public override bool IsPolynomial => FirstOperand.IsPolynomial && SecondOperand.IsPolynomial;
    public override int PolynomialDegree => Math.Max(FirstOperand.PolynomialDegree, SecondOperand.PolynomialDegree);
    public override double Compute(IReadOnlyDictionary<string, double> variableValues) =>
        FirstOperand.Compute(variableValues) + SecondOperand.Compute(variableValues);

    public override string ToString() => $"({FirstOperand} + {SecondOperand})";
}
public class Subtraction : BinaryOperation
{
    public Subtraction(Expression firstOperand, Expression secondOperand) : base(firstOperand, secondOperand) { }
    public override bool IsConstant => FirstOperand.IsConstant && SecondOperand.IsConstant;
    public override bool IsPolynomial => FirstOperand.IsPolynomial && SecondOperand.IsPolynomial;
    public override int PolynomialDegree => Math.Max(FirstOperand.PolynomialDegree, SecondOperand.PolynomialDegree);
    public override double Compute(IReadOnlyDictionary<string, double> variableValues) =>
        FirstOperand.Compute(variableValues) - SecondOperand.Compute(variableValues);
    public override string ToString() => $"({FirstOperand} - {SecondOperand})";
}
public class Multiplication : BinaryOperation
{
    public Multiplication(Expression firstOperand, Expression secondOperand) : base(firstOperand, secondOperand) { }
    public override bool IsConstant => FirstOperand.IsConstant && SecondOperand.IsConstant;
    public override bool IsPolynomial => FirstOperand.IsPolynomial && SecondOperand.IsPolynomial;
    public override int PolynomialDegree => FirstOperand.PolynomialDegree + SecondOperand.PolynomialDegree;
    public override double Compute(IReadOnlyDictionary<string, double> variableValues) =>
        FirstOperand.Compute(variableValues) * SecondOperand.Compute(variableValues);
    public override string ToString() => $"{FirstOperand} * {SecondOperand}";
}
public class Division : BinaryOperation
{
    public Division(Expression firstOperand, Expression secondOperand) : base(firstOperand, secondOperand) { }
    public override bool IsConstant => FirstOperand.IsConstant && SecondOperand.IsConstant;
    public override bool IsPolynomial =>
        FirstOperand.IsPolynomial && SecondOperand.IsPolynomial && SecondOperand.PolynomialDegree == 0;
    public override int PolynomialDegree => FirstOperand.PolynomialDegree;
    public override double Compute(IReadOnlyDictionary<string, double> variableValues) =>
        FirstOperand.Compute(variableValues) / SecondOperand.Compute(variableValues);
    public override string ToString() => $"{FirstOperand} / {SecondOperand}";
}
public abstract class UnaryOperation : Expression
{
    public override IEnumerable<string> Variables => Operand.Variables;

    public Expression Operand => operand;
    protected Expression operand;

    protected UnaryOperation(Expression operand)
    {
        this.operand = operand;
    }
    public abstract override string ToString();
}
public abstract class Function : UnaryOperation
{
    protected Function(Expression operand) : base(operand) { }
    public override bool IsPolynomial => false;
    public override int PolynomialDegree => 0;
}
public class Sqrt : Function
{
    public Sqrt(Expression operand) : base(operand){ }
    public override bool IsConstant => Operand.IsConstant;
    public override bool IsPolynomial => Operand.IsPolynomial && Operand.PolynomialDegree % 2 == 0;
    public override int PolynomialDegree => Operand.PolynomialDegree / 2;
    public override double Compute(IReadOnlyDictionary<string, double> variableValues)=> Math.Sqrt(operand.Compute(variableValues));
    public override string ToString() => $"Sqrt({Operand})";
}
public class Arsinh : Function
{
    public Arsinh(Expression operand) : base(operand) { }
    public override bool IsConstant => Operand.IsConstant;
    public override double Compute(IReadOnlyDictionary<string, double> variableValues) =>
        Math.Log(Operand.Compute(variableValues) + Math.Sqrt(Operand.Compute(variableValues) * Operand.Compute(variableValues) + 1));
    public override string ToString() => $"Arsinh({Operand})";
}
public class Arcosh : Function
{
    public Arcosh(Expression operand) : base(operand) { }
    public override bool IsConstant => Operand.IsConstant;
    public override double Compute(IReadOnlyDictionary<string, double> variableValues)
    {
        if (Operand.Compute(variableValues) < 1) throw new Exception("Аргумент Arcosh не принадлежит ОДЗ (x >= 1)!");
        return Math.Log(Operand.Compute(variableValues) + Math.Sqrt(Operand.Compute(variableValues) * Operand.Compute(variableValues) - 1));
    }
    public override string ToString() => $"Arcosh({Operand})";
}
public class Artanh : Function
{
    public Artanh(Expression operand) : base(operand) { }
    public override bool IsConstant => Operand.IsConstant;
    public override double Compute(IReadOnlyDictionary<string, double> variableValues)
    {
        if (Math.Abs(Operand.Compute(variableValues)) >= 1) throw new Exception("Аргумент Artanh не принадлежит ОДЗ (|x| < 1)!");
        return 0.5 * Math.Log(1 + (Operand.Compute(variableValues)) / (1 - Operand.Compute(variableValues)));
    }
    public override string ToString() => $"Artanh({Operand})";
}
public class Arcoth : Function
{
    public Arcoth(Expression operand) : base(operand) { }
    public override bool IsConstant => Operand.IsConstant;
    public override double Compute(IReadOnlyDictionary<string, double> variableValues)
    {
        if (Math.Abs(Operand.Compute(variableValues)) <= 1) throw new Exception("Аргумент Arcoth не принадлежит ОДЗ (|x| > 1)!");
        return 0.5 * Math.Log(1 + (Operand.Compute(variableValues)) / (Operand.Compute(variableValues) - 1));
    }
    public override string ToString() => $"Arcoth({Operand})";
}
public class Arcsech : Function
{
    public Arcsech(Expression operand) : base(operand) { }
    public override bool IsConstant => Operand.IsConstant;
    public override double Compute(IReadOnlyDictionary<string, double> variableValues)
    {
        if (Operand.Compute(variableValues) > 1 || Operand.Compute(variableValues) <= 0)
            throw new Exception("Аргумент Arcsech не принадлежит ОДЗ (0 < x <= 1)!");

        return Math.Log((1 + Math.Sqrt(1 - Operand.Compute(variableValues) * Operand.Compute(variableValues))) / Operand.Compute(variableValues));
    }
    public override string ToString() => $"Arcsech({Operand})";
}
public class Arccsch : Function
{
    public Arccsch(Expression operand) : base(operand) { }
    public override bool IsConstant => Operand.IsConstant;
    public override double Compute(IReadOnlyDictionary<string, double> variableValues)
    {
        if (Operand.Compute(variableValues) > 1 || Operand.Compute(variableValues) <= 0)
            throw new Exception("Аргумент Arccsch не принадлежит ОДЗ (x > 0)!");

        return Math.Log((1 + Math.Sqrt(1 + Operand.Compute(variableValues) * Operand.Compute(variableValues))) / Operand.Compute(variableValues));
    }
    public override string ToString() => $"Arccsch({Operand})";
}