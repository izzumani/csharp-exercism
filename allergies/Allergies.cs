using System;
using System.Collections.Generic;
using System.Linq;

[Flags]
public enum Allergen
{
    None = 0,
    Eggs =1,
    Peanuts = 2,
    Shellfish = 4,
    Strawberries =8,
    Tomatoes = 16,
    Chocolate = 32,
    Pollen = 64,
    Cats = 128
}

public class Allergies
{
    private readonly int _mask=0;
    public Allergies(int mask)
    {
        _mask = mask;
    }

    public bool IsAllergicTo(Allergen allergen)
    {
        return ((Allergen)_mask & allergen)!=0;
        

    }

    public Allergen[] List()
    {
        List<Allergen> allergenEnum = new();
        var _maskList = Enum.GetValues(typeof(Allergen));
       
        foreach (var enumValue in _maskList)
        {
            if(((Allergen)enumValue & (Allergen)_mask)!=0)
            {
                allergenEnum.Add((Allergen)enumValue);
            }
        }

     
        return allergenEnum.ToArray();
    }
}