using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ3
{
    public abstract class BinaryOperation : Expression
    {
        public override IEnumerable<string> Variables => FirstOperand.Variables.Union(SecondOperand.Variables);

        public Expression FirstOperand => firstOperand;
        protected Expression firstOperand;
        public Expression SecondOperand => secondOperand;
        protected Expression secondOperand;

        public override bool IsConstant => FirstOperand.IsConstant && SecondOperand.IsConstant;
        public override bool IsPolynomial => FirstOperand.IsPolynomial && SecondOperand.IsPolynomial;

        protected BinaryOperation(Expression firstOperand, Expression secondOperand)
        {
            this.firstOperand = firstOperand;
            this.secondOperand = secondOperand;
        }
    }
    public class Addition : BinaryOperation
    {
        public Addition(Expression firstOperand, Expression secondOperand) : base(firstOperand, secondOperand) { }

        public override int PolynomialDegree => Math.Max(FirstOperand.PolynomialDegree, SecondOperand.PolynomialDegree);
        public override double Compute(IReadOnlyDictionary<string, double> variableValues) =>
            FirstOperand.Compute(variableValues) + SecondOperand.Compute(variableValues);

        public override string ToString() => $"({FirstOperand} + {SecondOperand})";
    }
    public class Subtraction : BinaryOperation
    {
        public Subtraction(Expression firstOperand, Expression secondOperand) : base(firstOperand, secondOperand) { }
        public override int PolynomialDegree => Math.Max(FirstOperand.PolynomialDegree, SecondOperand.PolynomialDegree);
        public override double Compute(IReadOnlyDictionary<string, double> variableValues) =>
            FirstOperand.Compute(variableValues) - SecondOperand.Compute(variableValues);
        public override string ToString() => $"({FirstOperand} - {SecondOperand})";
    }
    public class Multiplication : BinaryOperation
    {
        public Multiplication(Expression firstOperand, Expression secondOperand) : base(firstOperand, secondOperand) { }
        public override int PolynomialDegree => FirstOperand.PolynomialDegree + SecondOperand.PolynomialDegree;
        public override double Compute(IReadOnlyDictionary<string, double> variableValues) =>
            FirstOperand.Compute(variableValues) * SecondOperand.Compute(variableValues);
        public override string ToString() => $"{FirstOperand} * {SecondOperand}";
    }
    public class Division : BinaryOperation
    {
        public Division(Expression firstOperand, Expression secondOperand) : base(firstOperand, secondOperand) { }
        public override bool IsPolynomial =>
            FirstOperand.IsPolynomial && SecondOperand.IsPolynomial && SecondOperand.PolynomialDegree == 0;
        public override int PolynomialDegree => FirstOperand.PolynomialDegree;
        public override double Compute(IReadOnlyDictionary<string, double> variableValues) =>
            FirstOperand.Compute(variableValues) / SecondOperand.Compute(variableValues);
        public override string ToString() => $"{FirstOperand} / {SecondOperand}";
    }
}
