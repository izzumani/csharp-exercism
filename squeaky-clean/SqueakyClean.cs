using System;
using System.Text;
using System.Globalization;
using System.Text.RegularExpressions;
public static class Identifier
{
    public static string Clean(string identifier)
    {
        string cleanText = Regex.Replace(identifier,@"\s","_");
        StringBuilder sbText = new StringBuilder();
        TextElementEnumerator charEnum = StringInfo.GetTextElementEnumerator(cleanText);
        bool nextCaseFlag = false;
        bool validCharacter = false;
        string charText = string.Empty;
        while (charEnum.MoveNext()) 
        {
            validCharacter = true;
            charText = charEnum.GetTextElement();
            if (char.IsControl(charText.ToCharArray()[0]))
            {
                charText = "CTRL";
                
            }

            if(nextCaseFlag==true)
            {
                charText = charText.ToUpper();
                nextCaseFlag=false;
            }
           

            if(charText=="-")
            {
                nextCaseFlag = true;
                validCharacter = false;
            }

            
            if(!char.IsLetter(charText.ToCharArray()[0]) && charText !="_")
            {
                validCharacter=false;
            }

            string greekLetters = "αβγδεζηθικλμνξοπρστυφχψω";
            if (greekLetters.Contains(charText))
            {
                validCharacter=false;
            }
            
            if (validCharacter==true)
            {
                sbText.Append(charText);    
            }
            
        }
        
     
        return sbText.ToString();
    }
}
