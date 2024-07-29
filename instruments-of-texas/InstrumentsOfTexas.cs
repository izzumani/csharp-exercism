using System;

public class CalculationException : Exception
{
    public CalculationException(int operand1, int operand2, string message, Exception inner)
        : base($" throw {message} during {operand1} and {operand2}",inner)
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
          
                
            Multiply(x, y);
            return "Multiply succeeded";
        }
        catch (CalculationException ex) when (!string.IsNullOrEmpty(ex.Message))
        {
            if (x<0 && y < 0)
                return $"Multiply failed for negative operands. {ex.InnerException.Message}";
            else
                return $"Multiply failed for mixed or positive operands. {ex.InnerException.Message}";
        }
    }

    public void Multiply(int x, int y)
    {
        try
        {
           
            calculator.Multiply(x, y);

        }
        catch (OverflowException ex) when (!string.IsNullOrEmpty(ex.Message))
        {

            throw new CalculationException(x, y, ex.Message, ex);
        }
        catch (Exception ex)
        {
            throw new CalculationException(x, y, ex.Message, ex);
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
