using System;

public class Player
{
    public int RollDie()
    {
        Random rnd = new Random();
        return rnd.Next(1,19);
    }

    public double GenerateSpellStrength()
    {
        Random rnd = new Random();
        double _returnValue = rnd.NextDouble()*(100d - 1d) *1d;
        Console.WriteLine(_returnValue);
        return _returnValue;
    }
}
