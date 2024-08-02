using System;
using System.Linq;
using System.Text.RegularExpressions;

public static class Bob
{
    public static string Response(string statement)
    {

        if (String.IsNullOrEmpty(statement.Trim()))
        {
            return "Fine. Be that way!";
        }
       else if (statement.Trim().All(x=> Char.IsUpper(x)) || Regex.Match(statement.Trim(), @"^[A-Z0-9]+[A-Z0-9\s\W]+[^a-z]*[^\?][A-Z|!]$").Success)
        {
            return "Whoa, chill out!";
        }
        else if (Regex.Match(statement.Trim(), @"^[A-Z]+[A-Z\s']+[^a-z]*[\?]$").Success)
        {
            return "Calm down, I know what I'm doing!";
        }
        else if (Regex.Match(statement.Trim(), @"^[A-Za-z0-9]*[a-z0-9\s\W!.]*[\?]$",RegexOptions.IgnoreCase).Success)

        {
            return "Sure.";
        }

        return "Whatever.";
    }
}