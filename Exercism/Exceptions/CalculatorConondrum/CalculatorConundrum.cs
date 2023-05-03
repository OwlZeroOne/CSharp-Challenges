namespace Challenges.Exercism.Exceptions.CalculatorConondrum;

public static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string operation)
    {
        switch (operation)
        {
            case "+":
                return $"{operand1} + {operand2} = {SimpleOperation.Addition(operand1, operand2).ToString()}";
            
            case "/":
                if (operand2 == 0) return "Division by zero is not allowed.";
                return $"{operand1} / {operand2} = {SimpleOperation.Division(operand1, operand2).ToString()}"; 
            
            case "*":
                return $"{operand1} * {operand2} = {SimpleOperation.Multiplication(operand1, operand2).ToString()}";
            
            case "":
                throw new ArgumentException();
            
            case null:
                throw new ArgumentNullException();
        }

        throw new ArgumentOutOfRangeException();
    }
}