namespace Challenges.Exercism;

public abstract class Character
{
    private string characterType;
    private bool isVulnerable;
    
    protected Character(string characterType)
    {
        this.characterType = characterType;
        isVulnerable = false;
    }

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable()
    {
        return isVulnerable;
    }

    /*
     * Overrides the "ToString()" method from the parent "Object" class.
     */
    public override string ToString()
    {
        return $"Character is a {characterType}";
    }
}

public class Warrior : Character
{
    public Warrior() : base("Warrior")
    {
    }

    public override int DamagePoints(Character target)
    {
        return target.Vulnerable() ? 10 : 6;
    }
}

public class Wizard : Character
{
    private bool spellPrepared;
    
    public Wizard() : base("Wizard")
    {
        spellPrepared = false;
        
    }

    public override int DamagePoints(Character target)
    {
        return spellPrepared ? 12 : 3;
    }

    public void PrepareSpell()
    {
        spellPrepared = true;
    }
    
    public override bool Vulnerable()
    {
        return !spellPrepared;
    }
}