namespace Challenges.Exercism.Strings;

public static class Acronym
{
    public static string Abbreviate(string phrase)
    {
        string newPhrase = Clean(phrase);
        Console.WriteLine(newPhrase);
        string[] words = newPhrase.Split(" ");
        string abbreviation = "";

        foreach (var word in words)
            abbreviation += char.ToUpper(word[0]);

        return abbreviation;
    }

    private static string Clean(string phrase)
    {
        var newPhrase = phrase;
        
        // replace dashes with white space
        newPhrase = newPhrase.Replace("-", " ");
        
        // remove underscores
        newPhrase = newPhrase.Replace("_", "");
        
        // trim consecutive white space
        newPhrase = TrimConsecutiveWhiteSpace(newPhrase);

        return newPhrase;
    }

    private static string TrimConsecutiveWhiteSpace(string phrase)
    {
        string newPhrase = "";

        for (int i = 0; i < phrase.Length; i++)
        {
            char character = phrase[i];

            if (char.IsWhiteSpace(character))
            {
                while (char.IsWhiteSpace(character))
                    character = phrase[++i];

                newPhrase += " ";
            }

            newPhrase += character;
        }

        return newPhrase;
    }
}