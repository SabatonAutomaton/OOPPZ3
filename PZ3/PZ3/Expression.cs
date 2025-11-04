using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ3;

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
