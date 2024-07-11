class Lasagna
{

    private const int expectedMinutes = 40;
    
    public int ExpectedMinutesInOven()
    {
        return expectedMinutes;
    }
    public int RemainingMinutesInOven(int actualMinutes)
    {
        return expectedMinutes - actualMinutes;
    }

    public int PreparationTimeInMinutes(int layers)
    {
        return layers * 2;
    }

    public int ElapsedTimeInMinutes(int layers, int ovenMinutes)
    {
        return PreparationTimeInMinutes(layers) + ovenMinutes;
    }


}
