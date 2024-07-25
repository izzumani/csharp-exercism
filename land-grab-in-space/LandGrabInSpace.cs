using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

public struct Coord
{
    public Coord(ushort x, ushort y)
    {
        X = x;
        Y = y;
    }

    public ushort X { get; }
    public ushort Y { get; }
}

public struct Plot : IEquatable<Plot>, IComparable<Plot>
{
    private Coord _coord1 = new();
    private Coord _coord2 = new();
    private Coord _coord3 = new(); 
    private Coord _coord4 = new();
    public Plot (Coord coord1, Coord coord2, Coord coord3, Coord coord4)
    {
        _coord1 = coord1;
        _coord2 = coord2;
        _coord3 = coord3;
        _coord4 = coord4;
    }

    public bool Equals(Plot plot)
    {
        return (
            this._coord1.X == plot._coord1.X
            && this._coord1.Y == plot._coord1.Y
            && this._coord2.X == plot._coord2.X
            && this._coord2.Y == plot._coord2.Y
            && this._coord3.X == plot._coord3.X
            && this._coord3.Y == plot._coord3.Y
            && this._coord4.X == plot._coord4.X
            && this._coord4.Y == plot._coord4.Y
            );
    }

    public int CompareTo(Plot plot)
    {
        if ( (_coord1.X + _coord2.X + _coord3.X + _coord4.X + _coord1.Y + _coord2.Y + _coord3.Y + _coord4.Y) > 
            (plot._coord1.X + plot._coord2.X + plot._coord3.X + plot._coord4.X + plot._coord1.Y + plot._coord2.Y + plot._coord3.Y + plot._coord4.Y))
        {
            return 1;
        }
        else if ((_coord1.X + _coord2.X + _coord3.X + _coord4.X + _coord1.Y + _coord2.Y + _coord3.Y + _coord4.Y) <
            (plot._coord1.X + plot._coord2.X + plot._coord3.X + plot._coord4.X + plot._coord1.Y + plot._coord2.Y + plot._coord3.Y + plot._coord4.Y))
        {
            return -1;  
        }
        else
        {
            return 0;
        }
    }

    public int GetHashCode()
    {
        return (_coord1.X + _coord2.X+_coord3.X + _coord4.X + _coord1.Y + _coord2.Y + _coord3.Y + _coord4.Y).GetHashCode();
    }
}


public class ClaimsHandler
{
    private List<Plot> _plot = new();
    public void StakeClaim(Plot plot)
    {
        _plot.Add(plot);
    }

    public bool IsClaimStaked(Plot plot)
    {
        return plot.Equals(_plot.Last());
    }

    public bool IsLastClaim(Plot plot)
    {
        return plot.GetHashCode() == _plot.Last().GetHashCode();
    }

    public Plot GetClaimWithLongestSide()
    {
        _plot.Sort();
        return _plot.Last();

    }
}
