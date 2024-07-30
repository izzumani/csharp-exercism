using System;
using System.Collections.Generic;
using System.Linq;

public class HighScores
{
    private readonly List<int> _list = new();
    public HighScores(List<int> list)
    {
        _list.AddRange(list);
    }

    public List<int> Scores()
    {
        return _list;
    }

    public int Latest()
    {
        return _list.Last();
    }

    public int PersonalBest()
    {
        return _list.Max();
    }

    public List<int> PersonalTopThree()
    {
        
       return _list.OrderByDescending(x=>x).Take(3).ToList();
    }
}