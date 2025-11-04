using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ3;

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
    public Sqrt(Expression operand) : base(operand) { }
    public override bool IsConstant => Operand.IsConstant;
    public override bool IsPolynomial => Operand.IsPolynomial && Operand.PolynomialDegree % 2 == 0;
    public override int PolynomialDegree => Operand.PolynomialDegree / 2;
    public override double Compute(IReadOnlyDictionary<string, double> variableValues) => Math.Sqrt(operand.Compute(variableValues));
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
