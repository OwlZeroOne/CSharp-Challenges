namespace Challenges.Exercism.Strings;

public static class RotationalCipher
{
    public static string Rotate(string text, int shiftKey)
    {
        string output = "";

        for (int i = 0; i < text.Length; i++)
        {
            char character = text[i];
            if (char.IsLetter(character))
                character = GetCharInRange(character, shiftKey);

            output += character;
        }

        return output;
    }

    // public static void Test()
    // {
    //     var str = "University-of-Edinburgh";
    //     Console.WriteLine(str);
    //     Console.WriteLine(Rotate(str, 10));
    // }
    
    private static char GetCharInRange(char character, int shiftKey)
    {
        var oldKey = CharToKey(character);

        int modulo = (oldKey.Key + shiftKey) % 26;
        int newKey = modulo == 0 ? 26 : modulo;
        
        return KeyToChar((newKey, oldKey.IsUpper));
    }

    /* ASCII letters decimals range from 65 to 90 for upper case and 97 to 122 for lowercase. ASCII characters with
     * decimals 61 to 66 are not letters.
     * Keys will be represented as a reduced form, ranging from 1 to 26 for upper case and 33 to 58 for lower case.
     */
    private static (int Key, bool IsUpper) CharToKey(char c)
    {
        int key;
        bool isUpper;
        int ascii = c;

        switch (ascii)
        {
            case >= 65 and <= 90:
                key = c - 64;
                isUpper = true;
                break;
            
            case >= 97 and <= 122:
                key = c - 96;
                isUpper = false;
                break;
            
            default:
                throw new ArgumentException($"Character '{c}' does not evaluate to a valid key! Decimal: {(int)c}; Acceptable Range: 65 <= c <= 90 or 97 <= c <= 122");
        }

        return (key, isUpper);
    }

    private static char KeyToChar((int Key, bool IsUpper) key)
    {
            int ascii;
            
            switch (key.IsUpper)
            {
                case true:
                    ascii = key.Key + 64;
                    break;
                
                case false:
                    ascii = key.Key + 96;
                    break;
            }

            char character = (char)ascii;
            
            if (!char.IsLetter(character))
                throw new ArgumentException($"Decimal {ascii} does not evaluate to a valid character! Decimal: {ascii}; Acceptable Range: 65 <= c <= 90 or 97 <= c <= 122");
            
            return character;
    }
    
}