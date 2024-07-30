using System;
using System.Collections.Generic;
using System.Globalization;

public static class Hamming
{
    public static int Distance(string firstStrand, string secondStrand)
    {
        if (firstStrand.Length != secondStrand.Length)
            throw new ArgumentException();
        
        string[] firstStrandArr = firstStrand.SplitString().ToArray();
        string[] secondStrandArr = secondStrand.SplitString().ToArray();


        int counter = 0;
        for (int i = 0; i < firstStrandArr.Length; i++)
        {
            if (!string.Equals(firstStrandArr[i], secondStrandArr[i], StringComparison.InvariantCultureIgnoreCase))
            {
                counter++;
            }
        }

        return counter;
    }

    public static List<string> SplitString(this string lineOfString)
    {
        TextElementEnumerator enumerator = StringInfo.GetTextElementEnumerator(lineOfString);
        List<string> result = new List<string>();
        while (enumerator.MoveNext())
        {
            result.Add(enumerator.Current.ToString());
        }

        return result;
    }
}