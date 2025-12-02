//using System.Reflection.Metadata;
using Newtonsoft.Json.Linq;
using PZ3;
using static PZ3.Expression;
namespace Tests;

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