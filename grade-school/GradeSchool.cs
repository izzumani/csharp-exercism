using System;
using System.Collections.Generic;
using System.Linq;

public class GradeSchool
{
    private Dictionary<string,int> studentDetails = new();
    public bool Add(string student, int grade)
    {
        return studentDetails.TryAdd(student, grade);
    }

    public IEnumerable<string> Roster()
    {
      
        return studentDetails.ToList().OrderBy(x=> x.Value).ThenBy(x=>x.Key).Select(x=> x.Key).AsEnumerable();
    }

    public IEnumerable<string> Grade(int grade)
    {
        
        return studentDetails.ToList().Where(x => x.Value == grade).OrderBy(x=> x.Key).Select(x => x.Key).AsEnumerable();


    }
}