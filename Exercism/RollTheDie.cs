using System;
/*
    Continuing the theme of the wizards and warriors game, it is time to add an all purpose die rolling method. This will be the traditional 18 sided die with numbers 1 to 18. Players also generate a spell strength.
*/
public class Player
{
    /*
        Implement a RollDie() method on the Player class.
    */
    public int RollDie()
    {
        return new Random().Next(1,19);
    }

    /*
        Implement a GenerateSpellStrength() method on the player class. The spell strength is between 0.0 and up to but not including 100.0.

        Note that spell strength must be a real number (not an integer) to reduce the possibility of a tie when the strengths of two adversaries are compared.
    */
    public double GenerateSpellStrength()
    {
        return new Random().NextDouble() * 100;
    }
}