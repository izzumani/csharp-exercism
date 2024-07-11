using System;
using System.Linq;
using System.Collections.Generic;
public static class DifferenceOfSquares
{
    public static int CalculateSquareOfSum(int max)
    {
        int sum = 0;
        List<int> _enumerable = Enumerable.Range(1, max).ToList();
        _enumerable.ForEach((x) =>{
            sum +=x;
            
        });
        return sum * sum;
    }

    public static int CalculateSumOfSquares(int max)
    {
        int sum = 0;
        List<int> _enumerable = Enumerable.Range(1, max).ToList();
        _enumerable.ForEach((x) =>{
            int square = x * x;
            sum +=square;
            
        });
        return sum;
        
    }

    public static int CalculateDifferenceOfSquares(int max) =>CalculateSquareOfSum(max) - CalculateSumOfSquares(max);
    
}