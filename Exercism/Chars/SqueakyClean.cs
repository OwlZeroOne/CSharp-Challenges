using System.Text;
/*
    In this exercise you will implement a partial set of utility routines to help a developer clean up identifier names.

    In the 5 tasks you will gradually build up the routine Clean A valid identifier comprises zero or more letters and underscores.

    In all cases the input string is guaranteed to be non-null. If an empty string is passed to the Clean function, an empty string should be returned.

    Note that the caller should avoid calling the routine Clean with an empty identifier since such identifiers are ineffectual.
*/
public static class Identifier
{
    /*
        Implement the (static) Identifier.Clean() method to replace any spaces with underscores. This also applies to leading and trailing spaces.

        Modify the (static) Identifier.Clean() method to replace control characters with the upper case string "CTRL".

        Modify the (static) Identifier.Clean() method to convert kebab-case to camelCase.

        Modify the (static) Identifier.Clean() method to omit any characters that are not letters.

        Modify the (static) Identifier.Clean() method to omit any Greek letters in the range 'α' to 'ω'.
    */
    public static string Clean(string identifier)
    {
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < identifier.Length; i++)
        {
            char ch = identifier[i];

            if (char.IsWhiteSpace(ch)) sb.Append("_");
            else if (char.IsControl(ch)) sb.Append("CTRL");
            else if (ch == '-')
            {
                sb.Append(char.ToUpper(identifier[i+1]));
                i++;
            }
            else if (!char.IsLetter(ch)) {/* DO NOTHING */}
            else if (ch.IsLowerGreek()) {/* DO NOTHING */}
            else sb.Append(ch);
        }

        return sb.ToString();
    }

    private static bool IsLowerGreek(this char character)
    {
        char[] lowerGreekLetters = {'α','β','γ','δ','ε','ζ','η','θ','ι','λ','μ','ν','ξ','ο','π','ρ','ς','σ','τ','υ','φ','χ','ψ','ω'};

        for (int i = 0; i < lowerGreekLetters.Length; i++)
            if (lowerGreekLetters[i] == character) return true;

        return false;
    }
}
