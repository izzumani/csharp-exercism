using System;

public class SpaceAge
{
    private const double _earthDays = 365.25;
    private const int _earthSeconds = 31_557_600;
    private readonly TimeSpan _ts;
    private readonly int _seconds;
    public SpaceAge(int seconds)
    {
        _ts = new TimeSpan(0, 0, seconds);
        _seconds = seconds;
    }

    public double OnEarth()
    {
        
        return Math.Round(_ts.Days / _earthDays, 2);
        
    }

    public double OnMercury()
    {

        //var _years = Math.Round(_ts.Days / (_earthDays * 0.2408467), 2);
        return Math.Round(((double)_seconds / (double)_earthSeconds) / 0.2408467, 2);

        //return Math.Round(_ts.Days / (_earthDays * 0.2408467), 2);

        
    }

    public double OnVenus()
    {
        return Math.Round(((double)_seconds / (double)_earthSeconds) / 0.61519726, 2);
        //return Math.Round(_ts.Days / (_earthDays * 0.61519726), 2);
    }

    public double OnMars()
    {

        return Math.Round(((double)_seconds / (double)_earthSeconds) / 1.8808158, 2);
        // return Math.Round(_ts.Days / (_earthDays * 1.8808158), 2);
    }

    public double OnJupiter()
    {
        return Math.Round(((double)_seconds / (double)_earthSeconds) / 11.862615, 2);
        //return Math.Round(_ts.Days / (_earthDays * 11.862615), 2);
    }

    public double OnSaturn()
    {
        return Math.Round(((double)_seconds / (double)_earthSeconds) / 29.447498, 2);
        //return Math.Round(_ts.Days / (_earthDays * 29.447498), 2);
    }

    public double OnUranus()
    {
        return Math.Round(((double)_seconds / (double)_earthSeconds) / 84.016846, 2);
        //return Math.Round(_ts.Days / (_earthDays * 84.016846), 2);
    }

    public double OnNeptune()
    {
        return Math.Round(((double)_seconds / (double)_earthSeconds) / 164.79132, 2);
        //return Math.Round(_ts.Days / (_earthDays * 164.79132), 2);
    }
}