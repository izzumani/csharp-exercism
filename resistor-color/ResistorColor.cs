using System;

public static class ResistorColor
{
    enum ResistorColorCode
    {
        black =0,
        brown=1,
        red=2,
        orange=3,
        yellow=4,
        green=5,
        blue=6,
        violet=7,
        grey=8,
        white=9
    }
    public static int ColorCode(string color)
    {
        return (int)Enum.Parse(typeof(ResistorColorCode), color);
        
    }

    public static string[] Colors()
    {
        return Enum.GetNames(typeof(ResistorColorCode));
    }
}