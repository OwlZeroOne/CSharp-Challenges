using System;
using System.Collections.Generic;

/*
    In this exercise you'll be writing code to keep track of a list of programming languages you want to learn on Exercism.

    You have nine tasks, which will all involve dealing with lists.
*/
public static class Languages
{
    /*
        To keep track of the languages you want to learn, you'll need to create a new list.
        Implement the static Languages.NewList() method that returns a new, empty list.
    */
    public static List<string> NewList()
    {
        return new List<string>();
    }

    /*
        Currently, you have a piece of paper listing the languages you want to learn: C#, Clojure and Elm.
        Please implement the static Languages.GetExistingLanguages() method to return the list.
    */
    public static List<string> GetExistingLanguages()
    {
        List<string> existingLanguages = new List<string>();
        existingLanguages.Add("C#");
        existingLanguages.Add("Clojure");
        existingLanguages.Add("Elm");

        return existingLanguages;
    }

    /*
        As you explore Exercism and find more interesting languages, you want to add them to your list.
        Implement the static Languages.AddLanguage() function to add a new language to the end of your list.
    */
    public static List<string> AddLanguage(List<string> languages, string language)
    {
        languages.Add(language);
        return languages;
    }

    /*
        Counting the languages one-by-one is inconvenient.
        Implement the static Languages.CountLanguages() method to count the number of languages on your list.
    */
    public static int CountLanguages(List<string> languages)
    {
        return languages.Count;
    }

    /*
        Implement the static Languages.HasLanguage() method to check if a language is present.
    */
    public static bool HasLanguage(List<string> languages, string language)
    {
        return languages.Contains(language);
    }

    /*
        At some point, you realize that your list is actually ordered backwards!
        Implement the static Languages.ReverseList() method to reverse your list.
    */
    public static List<string> ReverseList(List<string> languages)
    {
        languages.Reverse();
        return languages;
    }

    /*
        While you love all languages, C# has a special place in your heart. As such, you're really excited about a list of languages if:

        -   The first on the list is C#.
        -   The second item on the list is C# and the list contains either two or three languages.

        Implement the static Languages.IsExciting() method to check if a list of languages is exciting:
    */
    public static bool IsExciting(List<string> languages)
    {
        if (languages.Count > 0)
        {
            if (languages[0] == "C#") return true;
            else if (languages.Count > 1)
                if (languages[1] == "C#" && languages.Count <= 3) return true;;
        }

        return false;
    }

    /*
        Please implement the static Languages.RemoveLanguage() method to remove a specified language from the list.
    */
    public static List<string> RemoveLanguage(List<string> languages, string language)
    {
        languages.Remove(language);
        return languages;
    }

    /*
        Please implement the static Languages.IsUnique() method to check if any of the languages is repeated in the list.
        The list of languages (i.e. the parameter) is guaranteed not to be empty when this method is called and it doesn't matter if the list is modified.
    */
    public static bool IsUnique(List<string> languages)
    {
        for (int i = 0; i < languages.Count; i++)
        {
            string language = languages[i];
            for (int j = i+1; j < languages.Count; j++)
            {
                string anotherLanguage = languages[j];
                if (language == anotherLanguage) return false;
            }
        }
        return true;
    }
}