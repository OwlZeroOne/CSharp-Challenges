using System.Diagnostics;

namespace Challenges.Exercism;

[Flags]
enum AccountType
{
    Guest,
    User,
    Moderator
}

[Flags]
enum Permission
{
    None     = 0,    // 000
    Read     = 1,    // 001
    Write    = 2,    // 010
    Delete   = 4,    // 100
    All      = 7     // 111
}

static class Permissions
{
    public static Permission Default(AccountType accountType)
    {
        switch (accountType)
        {
            case AccountType.Guest:
                return Permission.Read;
            
            case AccountType.User:
                return Permission.Read | Permission.Write;
            
            case AccountType.Moderator:
                return Permission.Read | Permission.Write | Permission.Delete;
        }

        return Permission.None;
    }

    public static Permission Grant(Permission current, Permission grant)
    {
        // Cases where permissions are either All or None.
        switch (current)
        {
            case Permission.All:
                // Do nothing.
                break;
            
            case Permission.None:
                // Change permissions from None to something.
                return grant;
        }

        // If all individual permissions have been granted, change permissions to All.
        if ((current | grant) == (Permission.Read | Permission.Write | Permission.Delete)) return Permission.All;
        
        // Otherwise add a permission
        return current | grant;
    }

    public static Permission Revoke(Permission current, Permission revoke)
    {
        // Cases where permissions are either All or None.
        switch (current)
        {
            case Permission.All:
                // Remove one of the permissions.
                return EvalRevoke(current, revoke);
            
            case Permission.None:
                // Do nothing.
                break;
        }

        // Cases for revoking either All or None.
        switch (revoke)
        {
            case Permission.All:
                // Revoke all existing permissions.
                return Permission.None;
            
            case Permission.None:
                // Revoke no permissions.
                return current;
        }
        
        // If all permissions have been revoked, set permissions to None.
        if (EvalRevoke(current, revoke) == 0) return Permission.None;
        
        // Otherwise, revoke a permission
        return EvalRevoke(current, revoke);
    }

    /// <summary>
    /// Revoke permissions by ANDing the <paramref name="current"/> permissions with the complement of <paramref name="revoke"/> permissions.
    /// </summary>
    /// <param name="current">A combination of current permissions.</param>
    /// <param name="revoke">A combination of permissions to revoke.</param>
    /// <returns>The resultant combination of permissions.</returns>
    private static Permission EvalRevoke(Permission current, Permission revoke)
    {        
        return current & ~revoke;
    }

    public static bool Check(Permission current, Permission check)
    {
        return (int)(current & check) == (int)check;
    }
}