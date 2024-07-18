using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

public class FacialFeatures: IEquatable<FacialFeatures>
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }

    public int GetHashCode([DisallowNull] FacialFeatures obj)
    {
        return obj.GetHashCode();
    }

    public bool Equals(FacialFeatures objFacialFeatures2)
    {
        if (this == null && objFacialFeatures2 == null)
            return true;
        else if (this == null || objFacialFeatures2 == null)
            return false;
        else
            return (string.Equals(this.EyeColor, objFacialFeatures2.EyeColor, StringComparison.InvariantCultureIgnoreCase)
                && this.PhiltrumWidth == objFacialFeatures2.PhiltrumWidth);
    }
}

public class Identity : IEquatable<Identity>
{
    public string Email { get; }
    public FacialFeatures FacialFeatures { get; }

    public Identity(string email, FacialFeatures facialFeatures)
    {
        Email = email;
        FacialFeatures = facialFeatures;
    }

    public bool Equals(Identity _objId2)
    {
       
        if(this==null && _objId2==null)
            return true;
        else if (this == null || _objId2 == null)
            return false;
        else
        return (string.Equals(this.Email, _objId2.Email,StringComparison.InvariantCultureIgnoreCase) && this.FacialFeatures.Equals(_objId2.FacialFeatures));

    }

    public int GetHashCode([DisallowNull] Identity obj)
    {
        return obj.GetHashCode();
    }
    // TODO: implement equality and GetHashCode() methods
}

public class Authenticator
{
    private Identity _identity { get; set; } = new(string.Empty, new FacialFeatures(string.Empty, decimal.MinValue));
    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB)
    {
        return faceA.Equals(faceB);
    }

    public bool IsAdmin(Identity identity)
    {
        Identity theAdmin = new Identity("admin@exerc.ism", new FacialFeatures("green", 0.9m));
        return theAdmin.Equals(identity);
    }

    public bool Register(Identity identity)
    {
        if(IsRegistered(identity))
        {
            
            return false;
        }
        else
        {
            _identity = identity;
            return true;
        }

    }

    public bool IsRegistered(Identity identity)
    {
        return _identity.Equals(identity);
    }

    public static bool AreSameObject(Identity identityA, Identity identityB)
    {
        return ReferenceEquals(identityA, identityB);
            
    }
}
