using System;
using System.Collections.Generic;
using System.Linq;

public static class Languages
{
    
    public static List<string> NewList()
    {
        return new List<string>();
    }

    public static List<string> GetExistingLanguages()
    {
        return new List<string>() { "C#", "Clojure", "Elm" };
    }

    public static List<string> AddLanguage(List<string> languages, string language)
    {
        languages.Add(language);
        return languages;
    }

    public static int CountLanguages(List<string> languages)
    {
        return languages.Count;
    }

    public static bool HasLanguage(List<string> languages, string language)
    {
        return languages.Any(lang => string.Equals(lang, language,StringComparison.CurrentCultureIgnoreCase )); 
    }

    public static List<string> ReverseList(List<string> languages)
    {
        languages.Reverse();
        return languages;
    }

    public static bool IsExciting(List<string> languages)
    {
        var cSharpCount = languages.Count();

        if (cSharpCount > 0 && string.Equals(languages[0], "C#", StringComparison.InvariantCultureIgnoreCase))
        {
            return true;
        }
        else if ((cSharpCount > 1 && cSharpCount <= 3) && string.Equals(languages[1], "C#", StringComparison.InvariantCultureIgnoreCase)  )
        {
            return true;
        }
        else
        {
            return false;
        }
            
        
    }

    public static List<string> RemoveLanguage(List<string> languages, string language)
    {
        languages.Remove(language);
        return languages;
    }

    public static bool IsUnique(List<string> languages)
    {
        var listOfLanguages =  languages.GroupBy(p=> p).Select(grp => new { language = grp.Key, numberOfLanguages = grp.Count() }).ToList();
       
        return !listOfLanguages.Any(x => x.numberOfLanguages >1);

    }
}
