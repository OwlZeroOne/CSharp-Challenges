using System.Collections;

namespace Challenges.Exercism.Strings;

public static class Pangram
{
    public static bool IsPangram(string input)
    {
        List<char> letters = new List<char>();

        foreach (char character in input)
        {
            if (char.IsLetter(character))
            {
                char upperCaseLetter = char.ToUpper(character);
                if (!letters.Contains(upperCaseLetter))
                    letters.Add(upperCaseLetter);
            }
            if (letters.Count == 26) return true;
        }

        return false;
    }
}