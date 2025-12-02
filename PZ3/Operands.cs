using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ3
{
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
        public override string ToString() => (Value >= 0) ? Value.ToString() : "(" + Value.ToString() + ")";
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
}