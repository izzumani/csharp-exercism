using System;
using System.Text;
using System.Text.RegularExpressions;

public static class RotationalCipher
{
    private const string _alphabeticalorder = "abcdefghijklmnopqrstuvwxyz";
                                             
    public static string Rotate(string text, int shiftKey)
    {
        StringBuilder sb = new StringBuilder();
        string newAlphabetical = _alphabeticalorder.RotateAlphabeticalOrder(shiftKey);
      
        foreach(char textChar in text)
        {
            if(Char.IsLetter(textChar))
            {
                sb.Append( Char.IsAsciiLetterUpper(textChar) 
                    ? Char.ToString(newAlphabetical[_alphabeticalorder.IndexOf(Char.ToString(textChar).ToLower())]).ToUpper()
                    : Char.ToString(newAlphabetical[_alphabeticalorder.IndexOf(Char.ToString(textChar).ToLower())]));
            }
            else
            {
                sb.Append(Char.ToString(textChar));
            }
            
        }
         ;


        return sb.ToString();
    }

    public static string RotateAlphabeticalOrder(this string alphabeticalorder,int max)
    {
        string first_sub =alphabeticalorder.Substring(0,max);
        string second_sub = alphabeticalorder.Substring(max);

        return string.Concat(second_sub, first_sub);
    }
}