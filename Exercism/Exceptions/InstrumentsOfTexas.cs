namespace Challenges.Exercism.Exceptions;

public class CalculationException : Exception
{
    public CalculationException(int operand1, int operand2, string message, Exception inner) : base(message + " " + inner.Message)
    {
    }

    public int Operand1 { get; }
    public int Operand2 { get; }
}

public class CalculatorTestHarness
{
    private Calculator calculator;

    public CalculatorTestHarness(Calculator calculator)
    {
        this.calculator = calculator;
    }

    public string TestMultiplication(int x, int y)
    {
        try
        {
            Multiply(x,y);
        }
        catch (CalculationException e)
        {
        }

        return "Multiply succeeded";
    }

    public void Multiply(int x, int y)
    {
        string overflowMessage = "Arithmetic operation resulted in an overflow.";
        
        if (x < 0 || y < 0)
            throw new CalculationException(x,y, "Multiply failed for negative operands.",new OverflowException(overflowMessage));

        try
        {
            int product = checked(x * y);
        }
        catch(OverflowException exception)
        {
            throw new CalculationException(x, y, "Multiply failed for mixed or positive operands.", new OverflowException(overflowMessage));
        }
    }
}


// Please do not modify the code below.
// If there is an overflow in the multiplication operation
// then a System.OverflowException is thrown.
public class Calculator
{
    public int Multiply(int x, int y)
    {
        checked
        {
            return x * y;
        }
    }
}