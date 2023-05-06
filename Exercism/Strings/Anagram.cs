namespace Challenges.Exercism.Strings;

public class Anagram
{
    private string thisWord;
    
    public Anagram(string baseWord)
    {
        thisWord = baseWord.ToUpper();
    }

    public string[] FindAnagrams(string[] potentialMatches)
    {
        List<string> anagrams = new List<string>();

        foreach (string otherWord in potentialMatches)
        {
            // Initializes new states for each word in potentialMatches
            bool isAnagram = true;
            List<char> letters = BaseWordToList();
            string otherWordUpper = otherWord.ToUpper();
            
            // Compare letters in otherWord with letters of thisWord to see if it is an anagram.
            // otherWord is not an anagram when
            //  -   It is the same as thisWord
            //  -   It is longer than thisWord
            //  -   There is a letter mismatch
            //      -   Missing letter
            //      -   Ran out of particular letters
            if (LetterCountMatch(otherWordUpper) && ThisWordNotEqualTo(otherWordUpper))
            {
                foreach (char otherWordLetter in otherWordUpper)
                {
                    if(letters.Contains(otherWordLetter))
                        letters.Remove(otherWordLetter);
                    else
                    {
                        isAnagram = false;
                        Console.WriteLine($"'{otherWord}' is not an anagram of '{thisWord}' due to letter mismatch.");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine($"'{otherWord}' is not an anagram of '{thisWord}' due to character count difference.");
                isAnagram = false;
            }

            if (isAnagram)
            {
                anagrams.Add(otherWord);
            }
        }

        return anagrams.ToArray();
    }

    private bool LetterCountMatch(string otherWord)
    {
        return thisWord.Length == otherWord.Length;
    }

    private bool ThisWordNotEqualTo(string otherWord)
    {
        return thisWord != otherWord;
    }

    private List<char> BaseWordToList()
    {
        List<char> letters = new List<char>();

        foreach (var letter in thisWord)
            letters.Add(letter);

        return letters;
    }
}