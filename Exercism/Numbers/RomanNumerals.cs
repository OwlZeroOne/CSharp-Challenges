/*
    Write a function to convert from normal numbers to Roman Numerals.

    The Romans were a clever bunch. They conquered most of Europe and ruled it for hundreds of years. They invented concrete and straight roads and even bikinis. One thing they never discovered though was the number zero. This made writing and dating extensive histories of their exploits slightly more challenging, but the system of numbers they came up with is still in use today. For example the BBC uses Roman numerals to date their programs.

    The Romans wrote numbers using letters - I, V, X, L, C, D, M. (notice these letters have lots of straight lines and are hence easy to hack into stone tablets).

    1  => I
    10  => X
    7  => VII
    The maximum number supported by this notation is 3,999 (MMMCMXCIX). (The Romans themselves didn't tend to go any higher)

    Wikipedia says: Modern Roman numerals ... are written by expressing each digit separately starting with the left most digit and skipping any digit with a value of zero.

    To see this in practice, consider the example of 1990.

    In Roman numerals 1990 is MCMXC:

    1000=M 900=CM 90=XC

    2008 is written as MMVIII:

    2000=MM 8=VIII

    See also: https://wiki.imperivm-romanvm.com/wiki/Roman_Numerals
*/
public static class RomanNumerals
{
    /*
        The following values are denoted with above Roman Numerals:
        I - 1
        V - 5
        X - 10
        L - 50
        C - 100
        D - 500
        M - 1000

        In a single number, each digit has its own designated roman numeral representation based on its rank:
        -   units use I, V and X to denote units between 1 and 9.
        -   tens use X, L and C to denote tens between 10 and 90.
        -   hundreds use C, D and M to denote hundreds between 100 and 900.
        -   thousands use M to denote thousands from 1000 to 3000.
        
        Some sources say that 5000 can be represented by V-bar, but this value is out of the scope of this task.
    */
    public static string ToRoman(this int value)
    {
        string strValue = value.ToString();
        string thousand = "";
        string hundred  = "";
        string ten      = "";
        string unit     = "";

        for (int l = strValue.Length; l >= 1; l--)
        {
            int headDigit = strValue[0] - '0';
            switch (l)
            {
                case 4:
                    // Console.WriteLine("Entered case 4");
                    thousand = headDigit.Convert("M", null, null);
                    break;

                case 3:
                    // Console.WriteLine("Entered case 3");
                    hundred = headDigit.Convert("C", "D", "M");
                    break;

                case 2:
                    // Console.WriteLine("Entered case 2");
                    ten = headDigit.Convert("X", "L", "C");
                    break;

                case 1:
                    // Console.WriteLine("Entered case 1");
                    unit = headDigit.Convert("I", "V", "X");
                    break;
            }
            strValue = strValue.Substring(1);
        }

        return thousand + hundred + ten + unit;
    }

    private static string Convert(
        this int value,
        string first,
        string? second,
        string? third
        )
    {
        string numeral = "";

        if (second == null && third == null)
        {
            for (int i = 0; i < value; i++)
                numeral += "M";
        }
        else
        {
            if (value == 9) numeral += first + third;
            else if (value > 5)
            {
                numeral += second;
                for (int i = 0; i < value - 5; i++)
                    numeral += first;
            }
            else if (value == 5) numeral += second;
            else if (value == 4) numeral += first + second;
            else if (value > 0)
            {
                for (int i = 0; i < value; i++)
                    numeral += first;
            }
        }
        return numeral;
    }
}