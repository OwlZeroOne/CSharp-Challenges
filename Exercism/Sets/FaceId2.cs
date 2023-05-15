namespace Challenges.Exercism.Sets;

using System;
using System.Collections.Generic;

public class FacialFeatures
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }

    public override bool Equals(object? obj)
    {
        FacialFeatures ff;
        try
        {
            ff = (FacialFeatures)obj ?? throw new NullReferenceException();
        }
        catch (Exception e)
        {
            throw new ArgumentException("Unexpected object caught!");
        }

        if (EyeColor == ff.EyeColor && PhiltrumWidth == ff.PhiltrumWidth) return true;
        return false;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}

public class Identity
{
    public string Email { get; }
    public FacialFeatures FacialFeatures { get; }

    public Identity(string email, FacialFeatures facialFeatures)
    {
        Email = email;
        FacialFeatures = facialFeatures;
    }

    public override bool Equals(Object obj)
    {
        Identity id;
        try
        {
            id = (Identity)obj ?? throw new NullReferenceException();
        }
        catch (Exception e)
        {
            throw new ArgumentException("Unexpected object caught!");
        }

        if (Email == id.Email && FacialFeatures.Equals(id.FacialFeatures)) return true;
        return false;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}

public class Authenticator
{
    private HashSet<Identity> registeredIdentities;

    public Authenticator()
    {
        registeredIdentities = new HashSet<Identity>();
    }
    
    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB)
    {
        return faceA.Equals(faceB);
    }

    public bool IsAdmin(Identity identity)
    {
        Identity admin = new Identity("admin@exerc.ism", new FacialFeatures("green", 0.9m));

        return identity.Equals(admin);
    }

    public bool Register(Identity identity)
    {
        if (!IsRegistered(identity))
        {
            registeredIdentities.Add(identity);
            return true;
        }
        return false;
    }

    public bool IsRegistered(Identity otherIdentity)
    {
        foreach (Identity thisIdentity in registeredIdentities)
        {
            // Deep equality
            if (thisIdentity.Equals(otherIdentity)) return true;
        }

        return false;
    }

    public static bool AreSameObject(Identity identityA, Identity identityB)
    {
        // Shallow equality
        return identityA == identityB;
    }
}