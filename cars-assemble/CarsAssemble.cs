using System;

static class AssemblyLine
{
    private const int cars_produced =221;
    
    public static double SuccessRate(int speed)
    {
        if (speed ==0)
            return 0;
        else if(speed >= 1 && speed <=4)
            return Math.Round((1d),2);
        else if(speed >=5 && speed <=8)
            return Math.Round((0.90d),2);
        else if (speed ==9)
            return Math.Round((0.80d),2);
        else
            return Math.Round((0.77d),2);
    }
    
    public static double ProductionRatePerHour(int speed)
    {
        double _successRate =  SuccessRate(speed);
        return (cars_produced * speed) * _successRate;
    }

    public static int WorkingItemsPerMinute(int speed)
    {
         return (int)ProductionRatePerHour(speed)/60;
    }
}
