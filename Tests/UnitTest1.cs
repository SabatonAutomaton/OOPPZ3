//using System.Reflection.Metadata;
using Newtonsoft.Json.Linq;
using PZ3;
using static PZ3.Expression;
namespace Tests;

//UnaryOperations
public class UnitTestConstant
{
    [Fact]
    public void Constant_Compute()
    {
        //Arrange
        double value = 0.5;
        var c = new Constant(value);
        var variableValues = new Dictionary<string, double>();

        //Act
        double res = c.Compute(variableValues);

        //Assert
        Assert.Equal(value, res);
    }

    [Fact]
    public void Constant_ToString_Positive()
    {
        //Arrange
        double value = 0.5;
        var c = new Constant(value);

        //Act
        string res = c.ToString();

        //Assert
        Assert.Equal(value.ToString(), res);
    }

    [Fact]
    public void Constant_ToString_Negative()
    {
        //Arrange
        double value = -0.5;
        var c = new Constant(value);

        //Act
        string res = c.ToString();

        //Assert
        Assert.Equal("(" + value.ToString() + ")", res);
    }
}
public class UnitTestVariable
{
    [Fact]
    public void Variable_Compute()
    {
        //Arrange
        double value = 0.5;
        string name = "x";
        var x = new Variable(name);
        var variableValues = new Dictionary<string, double>() { { name, value } };

        //Act
        double res = x.Compute(variableValues);

        //Assert
        Assert.Equal(value, res);
    }

    [Fact]
    public void Variable_ToString()
    {
        //Arrange
        string name = "x";
        var x = new Variable(name);

        //Act
        string res = x.ToString();

        //Assert
        Assert.Equal(name, res);
    }
}
public class UnitTestSqrt
{
    [Fact]
    public void Sqrt_Compute_Constant()
    {
        //Arrange
        double val = 0.5;
        var c = new Constant(val);
        Expression expr = Sqrt(c);

        //Act
        double res = expr.Compute(new Dictionary<string, double>());

        //Assert
        Assert.Equal(Math.Sqrt(val), res);
    }

    [Fact]
    public void Sqrt_Compute_Variable()
    {
        //Arrange
        double val = 0.5;
        string name = "x";
        var x = new Variable(name);
        Expression expr = Sqrt(x);

        //Act
        double res = expr.Compute(new Dictionary<string, double>() { { name, val } });

        //Assert
        Assert.Equal(Math.Sqrt(val), res);
    }

    [Fact]
    public void Sqrt_ToString_Constant()
    {
        //Arrange
        double val = 0.5;
        var c = new Constant(val);
        Expression expr = Sqrt(c);

        //Act
        string res = expr.ToString();

        //Assert
        Assert.Equal("Sqrt(" + val.ToString() + ")", res);
    }

    [Fact]
    public void Sqrt_ToString_Variable()
    {
        //Arrange
        string name = "x";
        var x = new Variable(name);
        Expression expr = Sqrt(x);

        //Act
        string res = expr.ToString();

        //Assert
        Assert.Equal("Sqrt(" + name + ")", res);
    }
}
public class UnitTestArsinh
{
    [Fact]
    public void Arsinh_Compute_Constant()
    {
        //Arrange
        double val = 0.5;
        var c = new Constant(val);
        Expression expr = Arsinh(c);

        //Act
        double res = expr.Compute(new Dictionary<string, double>());

        //Assert
        Assert.Equal(Math.Log(val + Math.Sqrt(val * val + 1)), res);
    }

    [Fact]
    public void Arsinh_Compute_Variable()
    {
        //Arrange
        double val = 0.5;
        string name = "x";
        var x = new Variable(name);
        Expression expr = Arsinh(x);

        //Act
        double res = expr.Compute(new Dictionary<string, double>() { { name, val } });

        //Assert
        Assert.Equal(Math.Log(val + Math.Sqrt(val * val + 1)), res);
    }

    [Fact]
    public void Arsinh_ToString_Constant()
    {
        //Arrange
        double val = 0.5;
        var c = new Constant(val);
        Expression expr = Arsinh(c);

        //Act
        string res = expr.ToString();

        //Assert
        Assert.Equal("Arsinh(" + val.ToString() + ")", res);
    }

    [Fact]
    public void Arsinh_ToString_Variable()
    {
        //Arrange
        string name = "x";
        var x = new Variable(name);
        Expression expr = Arsinh(x);

        //Act
        string res = expr.ToString();

        //Assert
        Assert.Equal("Arsinh(" + name + ")", res);
    }
}
public class UnitTestArcosh
{
    [Fact]
    public void Arcosh_Compute_Constant_OutOfScope()
    {
        //Arrange
        double val = 0.5;
        var c = new Constant(val);
        Expression expr = Arcosh(c);
        bool outOfScope = false;

        //Act
        try
        {
            double res = expr.Compute(new Dictionary<string, double>());
        }
        catch (Exception ex)
        {
            outOfScope = true;
        }

        //Assert
        Assert.True(outOfScope);
    }

    [Fact]
    public void Arcosh_Compute_Constant_InScope()
    {
        //Arrange
        double val = 2;
        var c = new Constant(val);
        Expression expr = Arcosh(c);

        //Act
        double res = expr.Compute(new Dictionary<string, double>());

        //Assert
        Assert.Equal(Math.Log(val + Math.Sqrt(val * val - 1)), res);
    }

    [Fact]
    public void Arcosh_Compute_Variable()
    {
        //Arrange
        double val = 2;
        string name = "x";
        var x = new Variable(name);
        Expression expr = Arcosh(x);

        //Act
        double res = expr.Compute(new Dictionary<string, double>() { { name, val } });

        //Assert
        Assert.Equal(Math.Log(val + Math.Sqrt(val * val - 1)), res);
    }

    [Fact]
    public void Arcosh_ToString_Constant()
    {
        //Arrange
        double val = 0.5;
        var c = new Constant(val);
        Expression expr = Arcosh(c);

        //Act
        string res = expr.ToString();

        //Assert
        Assert.Equal($"Arcosh({val.ToString()})", res);
    }

    [Fact]
    public void Arcosh_ToString_Variable()
    {
        //Arrange
        string name = "x";
        var x = new Variable(name);
        Expression expr = Arcosh(x);

        //Act
        string res = expr.ToString();

        //Assert
        Assert.Equal($"Arcosh({name})", res);
    }
}
public class UnitTestArtanh
{
    [Fact]
    public void Artanh_Compute_Constant_OutOfScope()
    {
        //Arrange
        double val = 2;
        var c = new Constant(val);
        Expression expr = Artanh(c);
        bool outOfScope = false;

        //Act
        try
        {
            double res = expr.Compute(new Dictionary<string, double>());
        }
        catch (Exception ex)
        {
            outOfScope = true;
        }

        //Assert
        Assert.True(outOfScope);
    }

    [Fact]
    public void Artanh_Compute_Constant_InScope()
    {
        //Arrange
        double val = 0.5;
        var c = new Constant(val);
        Expression expr = Artanh(c);

        //Act
        double res = expr.Compute(new Dictionary<string, double>());

        //Assert
        Assert.Equal(0.5 * Math.Log((1 + val) / (1 - val)), res);
    }

    [Fact]
    public void Artanh_Compute_Variable()
    {
        //Arrange
        double val = 0.5;
        string name = "x";
        var x = new Variable(name);
        Expression expr = Artanh(x);

        //Act
        double res = expr.Compute(new Dictionary<string, double>() { { name, val } });

        //Assert
        Assert.Equal(0.5 * Math.Log((1 + val) / (1 - val)), res);
    }

    [Fact]
    public void Artanh_ToString_Constant()
    {
        //Arrange
        double val = 0.5;
        var c = new Constant(val);
        Expression expr = Artanh(c);

        //Act
        string res = expr.ToString();

        //Assert
        Assert.Equal($"Artanh({val.ToString()})", res);
    }

    [Fact]
    public void Artanh_ToString_Variable()
    {
        //Arrange
        string name = "x";
        var x = new Variable(name);
        Expression expr = Artanh(x);

        //Act
        string res = expr.ToString();

        //Assert
        Assert.Equal($"Artanh({name})", res);
    }
}
public class UnitTestArcoth
{
    [Fact]
    public void Arcoth_Compute_Constant_OutOfScope()
    {
        //Arrange
        double val = 0.5;
        var c = new Constant(val);
        Expression expr = Arcoth(c);
        bool outOfScope = false;

        //Act
        try
        {
            double res = expr.Compute(new Dictionary<string, double>());
        }
        catch (Exception ex)
        {
            outOfScope = true;
        }

        //Assert
        Assert.True(outOfScope);
    }

    [Fact]
    public void Arcoth_Compute_Constant_InScope()
    {
        //Arrange
        double val = 2;
        var c = new Constant(val);
        Expression expr = Arcoth(c);

        //Act
        double res = expr.Compute(new Dictionary<string, double>());

        //Assert
        Assert.Equal(0.5 * Math.Log((1 + val) / (val - 1)), res);
    }

    [Fact]
    public void Arcoth_Compute_Variable()
    {
        //Arrange
        double val = 2;
        string name = "x";
        var x = new Variable(name);
        Expression expr = Arcoth(x);

        //Act
        double res = expr.Compute(new Dictionary<string, double>() { { name, val } });

        //Assert
        Assert.Equal(0.5 * Math.Log((1 + val) / (val - 1)), res);
    }

    [Fact]
    public void Arcoth_ToString_Constant()
    {
        //Arrange
        double val = 0.5;
        var c = new Constant(val);
        Expression expr = Arcoth(c);

        //Act
        string res = expr.ToString();

        //Assert
        Assert.Equal($"Arcoth({val.ToString()})", res);
    }

    [Fact]
    public void Arcoth_ToString_Variable()
    {
        //Arrange
        string name = "x";
        var x = new Variable(name);
        Expression expr = Arcoth(x);

        //Act
        string res = expr.ToString();

        //Assert
        Assert.Equal($"Arcoth({name})", res);
    }
}
public class UnitTestArcsech
{
    [Fact]
    public void Arcsech_Compute_Constant_OutOfScope()
    {
        //Arrange
        double val = 2;
        var c = new Constant(val);
        Expression expr = Arcsech(c);
        bool outOfScope = false;

        //Act
        try
        {
            double res = expr.Compute(new Dictionary<string, double>());
        }
        catch (Exception ex)
        {
            outOfScope = true;
        }

        //Assert
        Assert.True(outOfScope);
    }

    [Fact]
    public void Arcsech_Compute_Constant_InScope()
    {
        //Arrange
        double val = 0.5;
        var c = new Constant(val);
        Expression expr = Arcsech(c);

        //Act
        double res = expr.Compute(new Dictionary<string, double>());

        //Assert
        Assert.Equal(Math.Log((1 + Math.Sqrt(1 - val * val)) / val), res);
    }

    [Fact]
    public void Arcsech_Compute_Variable()
    {
        //Arrange
        double val = 0.5;
        string name = "x";
        var x = new Variable(name);
        Expression expr = Arcsech(x);

        //Act
        double res = expr.Compute(new Dictionary<string, double>() { { name, val } });

        //Assert
        Assert.Equal(Math.Log((1 + Math.Sqrt(1 - val * val)) / val), res);
    }

    [Fact]
    public void Arcsech_ToString_Constant()
    {
        //Arrange
        double val = 0.5;
        var c = new Constant(val);
        Expression expr = Arcsech(c);

        //Act
        string res = expr.ToString();

        //Assert
        Assert.Equal($"Arcsech({val.ToString()})", res);
    }

    [Fact]
    public void Arcsech_ToString_Variable()
    {
        //Arrange
        string name = "x";
        var x = new Variable(name);
        Expression expr = Arcsech(x);

        //Act
        string res = expr.ToString();

        //Assert
        Assert.Equal($"Arcsech({name})", res);
    }
}
public class UnitTestArccsch
{
    [Fact]
    public void Arccsch_Compute_Constant_OutOfScope()
    {
        //Arrange
        double val = 0;
        var c = new Constant(val);
        Expression expr = Arccsch(c);
        bool outOfScope = false;

        //Act
        try
        {
            double res = expr.Compute(new Dictionary<string, double>());
        }
        catch (Exception ex)
        {
            outOfScope = true;
        }

        //Assert
        Assert.True(outOfScope);
    }

    [Fact]
    public void Arccsch_Compute_Constant_InScope()
    {
        //Arrange
        double val = 0.5;
        var c = new Constant(val);
        Expression expr = Arccsch(c);

        //Act
        double res = expr.Compute(new Dictionary<string, double>());

        //Assert
        Assert.Equal(Math.Log((1 + Math.Sqrt(1 + val * val)) / val), res);
    }

    [Fact]
    public void Arccsch_Compute_Variable()
    {
        //Arrange
        double val = 0.5;
        string name = "x";
        var x = new Variable(name);
        Expression expr = Arccsch(x);

        //Act
        double res = expr.Compute(new Dictionary<string, double>() { { name, val } });

        //Assert
        Assert.Equal(Math.Log((1 + Math.Sqrt(1 + val * val)) / val), res);
    }

    [Fact]
    public void Arccsch_ToString_Constant()
    {
        //Arrange
        double val = 0.5;
        var c = new Constant(val);
        Expression expr = Arccsch(c);

        //Act
        string res = expr.ToString();

        //Assert
        Assert.Equal($"Arccsch({val.ToString()})", res);
    }

    [Fact]
    public void Arccsch_ToString_Variable()
    {
        //Arrange
        string name = "x";
        var x = new Variable(name);
        Expression expr = Arccsch(x);

        //Act
        string res = expr.ToString();

        //Assert
        Assert.Equal($"Arccsch({name})", res);
    }
}

//BinaryOperations
public class UnitTestAddition
{
    [Fact]
    public void Addition_Compute()
    {
        //Arrange
        double val1 = 2;
        var c1 = new Constant(val1);

        double val2 = 2;
        var c2 = new Constant(val2);

        Expression expr = c1 + c2;

        //Act
        double res = expr.Compute(new Dictionary<string, double>());

        //Assert
        Assert.Equal(val1 + val2, res);
    }

    [Fact]
    public void Addition_ToSrting()
    {
        //Arrange
        double val1 = 2;
        var c1 = new Constant(val1);

        double val2 = 2;
        var c2 = new Constant(val2);

        Expression expr = c1 + c2;

        //Act
        string res = expr.ToString();

        //Assert
        Assert.Equal($"({val1} + {val2})", res);
    }
}
public class UnitTestSubtraction
{
    [Fact]
    public void Subtraction_Compute()
    {
        //Arrange
        double val1 = 2;
        var c1 = new Constant(val1);

        double val2 = 2;
        var c2 = new Constant(val2);

        Expression expr = c1 - c2;

        //Act
        double res = expr.Compute(new Dictionary<string, double>());

        //Assert
        Assert.Equal(val1 - val2, res);
    }

    [Fact]
    public void Subtraction_ToSrting()
    {
        //Arrange
        double val1 = 2;
        var c1 = new Constant(val1);

        double val2 = 2;
        var c2 = new Constant(val2);

        Expression expr = c1 - c2;

        //Act
        string res = expr.ToString();

        //Assert
        Assert.Equal($"({val1} - {val2})", res);
    }
}
public class UnitTestMultiplication
{
    [Fact]
    public void Multiplication_Compute()
    {
        //Arrange
        double val1 = 2;
        var c1 = new Constant(val1);

        double val2 = 2;
        var c2 = new Constant(val2);

        Expression expr = c1 * c2;

        //Act
        double res = expr.Compute(new Dictionary<string, double>());

        //Assert
        Assert.Equal(val1 * val2, res);
    }

    [Fact]
    public void Multiplication_ToSrting()
    {
        //Arrange
        double val1 = 2;
        var c1 = new Constant(val1);

        double val2 = 2;
        var c2 = new Constant(val2);

        Expression expr = c1 * c2;

        //Act
        string res = expr.ToString();

        //Assert
        Assert.Equal($"{val1} * {val2}", res);
    }
}
public class UnitTestDivision
{
    [Fact]
    public void Division_Compute()
    {
        //Arrange
        double val1 = 2;
        var c1 = new Constant(val1);

        double val2 = 2;
        var c2 = new Constant(val2);

        Expression expr = c1 / c2;

        //Act
        double res = expr.Compute(new Dictionary<string, double>());

        //Assert
        Assert.Equal(val1 / val2, res);
    }

    [Fact]
    public void Division_ToSrting()
    {
        //Arrange
        double val1 = 2;
        var c1 = new Constant(val1);

        double val2 = 2;
        var c2 = new Constant(val2);

        Expression expr = c1 / c2;

        //Act
        string res = expr.ToString();

        //Assert
        Assert.Equal($"{val1} / {val2}", res);
    }
}

//Тесты из задания
public class UnitTest
{
    [Fact]
    public void Expration_expr1ToString()
    {
        //Arrange
        var x = new Variable("x");
        var y = new Variable("y");
        var expr1 = (x - 4) * (3 * x + y * y) / 5;

        //Act
        var res = expr1.ToString();

        //Assert
        Assert.Equal($"(x - 4) * (3 * x + y * y) / 5", res);
    }

    [Fact]
    public void Expration_expr1Variables()
    {
        //Arrange
        var x = new Variable("x");
        var y = new Variable("y");
        var expr1 = (x - 4) * (3 * x + y * y) / 5;

        //Act
        var res = expr1.Variables;

        //Assert
        Assert.Equal(["x", "y"], res);
    }

    [Fact]
    public void Expration_expr1IsConstant()
    {
        //Arrange
        var x = new Variable("x");
        var y = new Variable("y");
        var expr1 = (x - 4) * (3 * x + y * y) / 5;

        //Act
        var res = expr1.IsConstant;

        //Assert
        Assert.False(res);
    }

    [Fact]
    public void Expration_expr1IsPolynomial()
    {
        //Arrange
        var x = new Variable("x");
        var y = new Variable("y");
        var expr1 = (x - 4) * (3 * x + y * y) / 5;

        //Act
        var res = expr1.IsPolynomial;

        //Assert
        Assert.True(res);
    }

    [Fact]
    public void Expration_expr1PolynomialDegree()
    {
        //Arrange
        var x = new Variable("x");
        var y = new Variable("y");
        var expr1 = (x - 4) * (3 * x + y * y) / 5;

        //Act
        var res = expr1.PolynomialDegree;

        //Assert
        Assert.Equal(3, res);
    }

    [Fact]
    public void Expration_expr1Compute()
    {
        //Arrange
        var x = new Variable("x");
        var y = new Variable("y");
        var expr1 = (x - 4) * (3 * x + y * y) / 5;

        //Act
        var res = expr1.Compute(new Dictionary<string, double> { ["x"] = 1, ["y"] = 2 });

        //Assert
        Assert.Equal(-4.2, res);
    }

    [Fact]
    public void Expration_expr2ToString()
    {
        //Arrange
        var c = new Constant(3);
        var expr2 = (5 - 3 * c) * Sqrt(16 + c * c);

        //Act
        var res = expr2.ToString();

        //Assert
        Assert.Equal($"(5 - 3 * 3) * Sqrt((16 + 3 * 3))", res);
    }

    [Fact]
    public void Expration_expr2Variables()
    {
        //Arrange
        var c = new Constant(3);
        var expr2 = (5 - 3 * c) * Sqrt(16 + c * c);

        //Act
        var res = expr2.Variables;

        //Assert
        Assert.Equal([], res);
    }

    [Fact]
    public void Expration_expr2IsConstant()
    {
        //Arrange
        var c = new Constant(3);
        var expr2 = (5 - 3 * c) * Sqrt(16 + c * c);

        //Act
        var res = expr2.IsConstant;

        //Assert
        Assert.True(res);
    }

    [Fact]
    public void Expration_expr2IsPolynomial()
    {
        //Arrange
        var c = new Constant(3);
        var expr2 = (5 - 3 * c) * Sqrt(16 + c * c);

        //Act
        var res = expr2.IsPolynomial;

        //Assert
        Assert.True(res);
    }

    [Fact]
    public void Expration_expr2PolynomialDegree()
    {
        //Arrange
        var c = new Constant(3);
        var expr2 = (5 - 3 * c) * Sqrt(16 + c * c);

        //Act
        var res = expr2.PolynomialDegree;

        //Assert
        Assert.Equal(0, res);
    }

    [Fact]
    public void Expration_expr2Compute()
    {
        //Arrange
        var c = new Constant(3);
        var expr2 = (5 - 3 * c) * Sqrt(16 + c * c);

        //Act
        var res = expr2.Compute(new Dictionary<string, double> { ["x"] = 1, ["y"] = 2 });

        //Assert
        Assert.Equal(-20, res);
    }
}