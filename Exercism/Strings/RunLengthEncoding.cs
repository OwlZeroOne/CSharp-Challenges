using System.Security.Cryptography.X509Certificates;

namespace Challenges.Exercism.Strings;

public static class RunLengthEncoding
{
    public static string Encode(string input)
    {
        if (input == "") return "";
        
        input += " ";
        
        string output = "";
        char previous = (char)0;
        int counter = 0;

        for (int i = 0; i < input.Length; i++)
        {
            char current = input[i];
            
            Console.WriteLine($"{i}:{current} : {previous}");

            if (i == input.Length - 1)
                output += (counter == 1 ? "" : counter.ToString()) + previous;
            else if (current != previous && previous != (char)0)
            {
                Console.WriteLine(counter);
                output += (counter == 1 ? "" : counter.ToString()) + previous;
                counter = 0;
            }

            previous = current;
            counter++;
        }

        return output;
    }

    public static string Decode(string input)
    {
        string output = "";
        
        for (int i = 0; i < input.Length; i++)
        {
            char current = input[i];

            if (char.IsDigit(current))
            {
                var multiplier = FindMultiplier(input, i);
                int number = multiplier.Result;
                i += multiplier.Skip;
                current = input[i];
                output += Replicate(current, number);
            }
            else output += current;
        }

        return output;
    }

    private static (int Result, int Skip) FindMultiplier(string str, int index)
    {
        string strNumber = str[index].ToString();
        char next = str[index + 1];
        int skip = 1;

        if (char.IsDigit(next))
        {
            strNumber += next;
            skip = 2;
        }
        
        return (int.Parse(strNumber), skip);
    }

    private static string Replicate(char character, int replicateNumber)
    {
        string output = "";

        for (int i = 0; i < replicateNumber; i++) output += character;

        return output;
    }
}