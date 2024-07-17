using System;
using System.Collections.Generic;

public interface IRemoteControlCar
{
    int DistanceTravelled { get; }
    void Drive();
}

public class ProductionRemoteControlCar : IRemoteControlCar, IComparable<ProductionRemoteControlCar>
{
    public int DistanceTravelled { get; private set; }
    public int NumberOfVictories { get; set; }

    public void Drive()
    {
        DistanceTravelled += 10;
    }

    public int CompareTo(ProductionRemoteControlCar other)
    {
       if(this.NumberOfVictories < other.NumberOfVictories)
        {

        return -1; 
        
        }
        else if (this.NumberOfVictories > other.NumberOfVictories)
        {
            return 1;
        }
       else
        {
            return 0;   
        }
       
    }
}

public class ExperimentalRemoteControlCar : IRemoteControlCar
{
    public int DistanceTravelled { get; private set; }

    public void Drive()
    {
        DistanceTravelled += 20;
    }
}

public static class TestTrack
{
    public static void Race(IRemoteControlCar car)
    {
        car.Drive();
    }

    public static List<ProductionRemoteControlCar> GetRankedCars(ProductionRemoteControlCar prc1,ProductionRemoteControlCar prc2)
    {
        var _sortedRankCars =  new List<ProductionRemoteControlCar> { prc1, prc2 };
        _sortedRankCars.Sort();
        return _sortedRankCars ;
    }
}
