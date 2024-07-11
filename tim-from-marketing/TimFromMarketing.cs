using System;

static class Badge
{
    
    public static string Print(int? id, string name, string? department)
    {
       
        if(id ==null && !string.IsNullOrEmpty(department))
        {
            return $"{name} - {department.ToUpper()}";
        }
        else if (string.IsNullOrEmpty(department))
        {

            return id != null ? $"[{id}] - {name} - OWNER" : $"{name} - OWNER";
            
        }
        else
        {
            return $"[{id}] - {name} - {department.ToUpper()}";
            
        }

    }
}
