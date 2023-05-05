using System.Collections.Generic;

namespace Challenges.Exercism.Strings;

public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        List<char> letters = new List<char>();

        foreach (char character in word)
        {
            if (char.IsLetter(character))
            {
                char upperCaseLetter = char.ToUpper(character);
                
                if (letters.Contains(upperCaseLetter)) return false;
                letters.Add(upperCaseLetter);
            }
        }

        return true;
    }
}