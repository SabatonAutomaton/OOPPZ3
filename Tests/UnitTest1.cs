//using System.Reflection.Metadata;
using PZ3;
namespace Tests;

public class UnitTest1
{
    [Fact]
    public void Constant_Compute_Double()
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
    public void Constant_ToString_String()
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
    public void Variable_Compute_Double()
    {
        //Arrange
        double value = 0.5;
        string name = "x";
        var x = new Variable(name);
        var variableValues = new Dictionary<string, double>() { {name, value } };

        //Act
        double res = x.Compute(variableValues);

        //Assert
        Assert.Equal(value, res);
    }

    [Fact]
    public void Variable_ToString_String()
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
