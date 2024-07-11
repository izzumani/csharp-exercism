using System;
using System.Linq;
class BirdCount
{
    private int[] birdsPerDay;
    private int[] birdsLastWeek = {0, 2, 5, 3, 7, 8, 4};

    public BirdCount(){}

    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek()
    {
        return new BirdCount().birdsLastWeek;
    }

    public int Today()
    {
        int _length = this.birdsPerDay.Length;
        
        return this.birdsPerDay[_length-1];;
    }

    public void IncrementTodaysCount()
    {
         int _length = this.birdsPerDay.Length;
        int _todayCount = this.birdsPerDay[_length - 1];
        this.birdsPerDay[_length - 1] = _todayCount + 1;
    }

    public bool HasDayWithoutBirds()
    {
        return this.birdsPerDay.ToList().Any(x=> x==0);
    }

    public int CountForFirstDays(int numberOfDays)
    {
        return this.birdsPerDay.ToList().Take(numberOfDays).Sum();
    }

    public int BusyDays()
    {
        return this.birdsPerDay.ToList().Where(x=> x>=5).Count();
    }
}
