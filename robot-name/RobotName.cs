using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Robot
{

    public static List<string> generatedCodeStore = new List<string>();
    private string _name = string.Empty;

    public Robot()
    {
        _name = GetRandomIdentifier();
    }
    public string Name
    {
        get
        {
            return _name;
        }
    }

    public void Reset()
    {
        generatedCodeStore.Clear();
        _name = GetRandomIdentifier();
    }

    public string GetRandomIdentifier()
    {
        
        List<string> _alphabetical = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray().Select(x=> Char.ToString(x)).ToList();
        List<int> _numerical = new List<int>() {0,1,2,3,4,5,6,7,8,9 };

        int alphIndex_1 = -1;
        int alphIndex_2 = -1;
        int maxRange =26;
        int[] existing = { -1, alphIndex_1, alphIndex_2 };
        int numIndex_1 = 0;


        int numIndex_2 = 0;
        int numIndex_3 = 0;

        int[] existingNum = { -1, numIndex_1, numIndex_2, numIndex_3 };
        string generatedCode = string.Empty;
        do
        {
            alphIndex_1 = alphIndex_1.generateUnique(maxRange, existing);
            existing[1] = alphIndex_1;
            alphIndex_2 = alphIndex_2.generateUnique(maxRange, existing);

            maxRange = 9;


            numIndex_1 = numIndex_1.generateUnique(maxRange, existingNum);
            existingNum[1] = numIndex_1;
            numIndex_2 = numIndex_2.generateUnique(maxRange, existingNum);
            existingNum[2] = numIndex_2;
            numIndex_3 = numIndex_3.generateUnique(maxRange, existingNum);

            generatedCode = $"{_alphabetical[alphIndex_1]}{_alphabetical[alphIndex_2]}{_numerical[numIndex_1]}{_numerical[numIndex_2]}{_numerical[numIndex_3]}";
        } while (generatedCodeStore.Any(x=> string.Equals(x, generatedCode,StringComparison.InvariantCultureIgnoreCase)));
        generatedCodeStore.Add(generatedCode);

        return generatedCode;
    }
}

public static class RobotExtension
{

    public static int generateUnique(this int value, int maxRange, int[] existing)
    {
        Random rnd = new Random();
        int unique = value;
        while (existing.Contains(unique)) 
        {
            unique = rnd.Next(maxRange);
        }

        return unique;
    }
}

