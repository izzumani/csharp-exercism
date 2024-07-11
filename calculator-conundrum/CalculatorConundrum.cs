using System;
using Xunit.Sdk;

public static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string operation)
    {
        switch (operation)
        {
            case "+":
                return $"{operand1} + {operand2} = {operand1 + operand2}";
            case "*":
                return $"{operand1} * {operand2} = {operand1 * operand2}";
            case "/":

                //return operand2 == 0 ? "Division by zer is not allowed." : $"{operand1} / {operand2} = {operand1 / operand2}";
                try
                {
                    
                    return $"{operand1} / {operand2} = {operand1 / operand2}";
                }
                catch (DivideByZeroException)
                {

                    return "Division by zero is not allowed.";
                }
                catch(Exception ex)
                {
                    throw ex;
                }
                
            case "":
                throw new ArgumentException();
            case null:
                throw new ArgumentNullException();
            default:
                throw new ArgumentOutOfRangeException();
                
        }
    }
}
