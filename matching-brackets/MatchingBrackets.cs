using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public static class MatchingBrackets
{
    private static IDictionary<char,char> bracketsObj = new Dictionary<char, char>() { 
                                                                                        {'[',']' } ,
                                                                                        {'(',')' },
                                                                                        {'{','}' }
                                                                                       };
    public static bool IsPaired(string input)
    {
        if (string.IsNullOrEmpty(input)) return true;
        Queue brackets = new Queue(input.Where(x => bracketsObj.Keys.Contains(x) || bracketsObj.Values.Contains(x)).ToList());
        Stack penClosingBracket = new Stack();

        if (brackets.Count > 0)
        {
          
           while(brackets.Count > 0)
            {
                var _charValue = (char)brackets.Dequeue();
                if(bracketsObj.TryGetValue(_charValue,out char value))
                {
                    penClosingBracket.Push(value);
                }
                else if (penClosingBracket.Count > 0 && (char)penClosingBracket.Peek()== _charValue)
                {
                    penClosingBracket.Pop();
                }
                else
                {
                    return false;
                    
                }
            }
            return penClosingBracket.Count > 0 ? false:true;
        }
        
            return false;
    }
}
