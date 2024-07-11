using System;

public static class Darts
{
    public static int Score(double x, double y)
    {
       double squareProduct = (x*x) + (y*y);
    

        if (squareProduct <=1)
        {
            return 10;
        }
        else if (squareProduct <=25)
        {
            return 5;
        }
        else if (squareProduct <=100)
        {
            return 1;
        }
        else{
            return 0;
        }
            
    }
}
