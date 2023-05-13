/*
    Bob is a lackadaisical teenager. In conversation, his responses are very limited.

    Bob answers 'Sure.' if you ask him a question, such as "How are you?".

    He answers 'Whoa, chill out!' if you YELL AT HIM (in all capitals).

    He answers 'Calm down, I know what I'm doing!' if you yell a question at him.

    He says 'Fine. Be that way!' if you address him without actually saying anything.

    He answers 'Whatever.' to anything else.

    Bob's conversational partner is a purist when it comes to written communication and always follows normal rules regarding sentence punctuation in English.
*/
public static class Bob
{
    public static string Response(string statement)
    {
        if (statement.YellQuestion()) return "Calm down, I know what I'm doing!";
        else if (statement.Yell()) return "Whoa, chill out!";
        else if (statement.Question()) return "Sure.";
        else if (statement.Silence()) return "Fine. Be that way!";
        else return "Whatever.";
    }

    private static bool YellQuestion(this string str)
    {
        return str.Yell() && str.Question();
    }

    private static bool Question(this string str)
    {
        string newString = str.Trim();
        if (newString != "")
            return newString[newString.Length - 1] == '?';
        return false;
    }

    private static bool Yell(this string str)
    {
        bool allCapitals = false;

        foreach (char character in str)
            if (char.IsLower(character))
            {
                allCapitals = false;
                break;
            }
            else if (char.IsUpper(character)) allCapitals = true;

        return allCapitals;
    }

    private static bool Silence(this string str)
    {
        return str.Trim() == "";
    }
}