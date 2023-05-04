namespace Challenges.Exercism.Exceptions;

public static class CentralBank
{
    public static string DisplayDenomination(long @base, long multiplier)
    {
        long denomination = 0;
        
        try
        {
            denomination = @base * multiplier;
            if (denomination < 0) throw new OverflowException();
        }
        catch (OverflowException)
        {
            return "*** Too Big ***";
        }

        return denomination.ToString();
    }

    public static string DisplayGDP(float @base, float multiplier)
    {
        float denomination = 0;
        
        try
        {
            denomination = @base * multiplier;
            if (denomination > float.MaxValue) throw new OverflowException();
        }
        catch (OverflowException)
        {
            return "*** Too Big ***";
        }

        return denomination.ToString();
    }

    public static string DisplayChiefEconomistSalary(decimal salaryBase, decimal multiplier)
    {
        decimal denomination = 0;
        
        try
        {
            denomination = salaryBase * multiplier;
        }
        catch (OverflowException)
        {
            return "*** Much Too Big ***";
        }

        return denomination.ToString();
    }
}