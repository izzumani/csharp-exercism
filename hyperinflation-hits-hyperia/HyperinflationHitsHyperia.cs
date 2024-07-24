using System;

public static class CentralBank
{
    public static string DisplayDenomination(long @base, long multiplier)
    {
        try
        {
            var result = checked(@base * multiplier);
            return result.ToString();
        }
        catch (OverflowException ex)
        {

            return "*** Too Big ***";
        }
        catch (Exception ex) 
        { 
            throw ex;
        }
        
    }

    public static string DisplayGDP(float @base, float multiplier)
    {
     
            var result = checked(@base * multiplier);
            if (float.IsPositiveInfinity(result))
                return "*** Too Big ***";
            
            return result.ToString();
     
    }

    public static string DisplayChiefEconomistSalary(decimal salaryBase, decimal multiplier)
    {
        try
        {
            var result = checked(salaryBase * multiplier);
            return result.ToString();
        }
        catch (OverflowException ex)
        {

            return "*** Much Too Big ***";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
