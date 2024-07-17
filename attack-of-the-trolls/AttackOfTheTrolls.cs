using System;

[Flags]
public enum AccountType
{
    Guest =Permission.Read,
    User = Permission.Read | Permission.Write,
    Moderator = Permission.All
}



[Flags]
public enum Permission
{
    None=0,
    Read=1<<1, 
    Write = 1 << 2,
    Delete = 1<<3,
    All=Read | Write | Delete,
    
}

static class Permissions
{
    public static Permission Default(AccountType accountType) => Enum.IsDefined(typeof(AccountType), accountType) ? (Permission) accountType : Permission.None;
    
    public static Permission Grant(Permission current, Permission grant)
    {
        return current | grant;
    }

    public static Permission Revoke(Permission current, Permission revoke)
    {
        return current &= ~revoke; 
        
    }

    public static bool Check(Permission current, Permission check)
    {
        return current.HasFlag(check);
    }
}
