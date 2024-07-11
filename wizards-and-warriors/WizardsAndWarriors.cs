using System;

abstract class Character
{
    protected Character(string characterType)
    {
        
    }

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable()
    {
        return false;
    }

    public override string ToString()
    {
       return "Character is a ...";
    }
}

class Warrior : Character
{
    private int DamageDealPoints{get;set;} = 6;
    public Warrior() : base("TODO")
    {
    }

    public override int DamagePoints(Character target)
    {
        if(target.Vulnerable())
        {
            return 10;
        }
        else{
            return 6;
        }
    }

     public override string ToString()
    {
       return "Character is a Warrior";
    }

     public override bool Vulnerable()
    {
        return false;
    }
}

class Wizard : Character
{
    private int DamageDealPoints{get;set;} = 3;
    private bool _vulnerable {get;set;}=true;
    public Wizard() : base("TODO")
    {
    }

    public override int DamagePoints(Character target)
    {
        return DamageDealPoints;
    }

    public void PrepareSpell()
    {
        DamageDealPoints=12;
        _vulnerable =false;
    }

      public override bool Vulnerable()
    {
        return _vulnerable;
    }
    public override string ToString()
    {
         return "Character is a Wizard";
    }
}
