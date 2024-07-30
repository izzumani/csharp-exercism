using System;
using System.Collections.Generic;

public static class NucleotideCount
{
   enum NucleotideEnum
    {
        A=0,
        C=1,
        G=2, 
        T=3,

    }
    public static IDictionary<char, int> Count(string sequence)
    {
        char[] chars = sequence.ToCharArray();
         Dictionary<char, int> nucleotideDict = new() { 
             {'A',0 },
             {'C',0 },
             {'G',0 },
             {'T',0 }
         };

        foreach (char _char in chars)
        {
            //var _testCharEnum = Enum.Parse(typeof(NucleotideEnum), Char.ToString(_char));
            //var convertedChar = Convert.ToChar(_testCharEnum.ToString());

            //if (nucleotideDict.TryGetValue(Convert.ToChar(_testCharEnum.ToString()), out int value))
            if (nucleotideDict.TryGetValue(_char, out int value))
            {
                nucleotideDict[_char] = value + 1;
            }
            else
            {
                throw new ArgumentException();
            }
          
        }
        return nucleotideDict;
    }
}