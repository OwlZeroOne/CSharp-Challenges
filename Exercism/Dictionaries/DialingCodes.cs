using System;
using System.Collections.Generic;

/// <summary>
/// In this exercise you'll be writing code to keep track of international dialling codes via an 
/// international dialing code dictionary. The dictionary uses an integer for its keys (the dialing code) 
/// and a string (country name) for its values. You have 9 tasks which involve the DialingCodes static 
/// class.
/// </summary>
public static class DialingCodes
{
    /// <summary>
    /// Implement the (static) method DialingCodes.GetEmptyDictionary() that returns an empty dictionary.
    /// </summary>
    public static Dictionary<int, string> GetEmptyDictionary()
    {
        return new Dictionary<int, string>();
    }

    /// <summary>
    /// There exists a pre-populated dictionary which contains the following 3 dialing codes: "United 
    /// States of America" which has a code of 1, "Brazil" which has a code of 55 and "India" which has a 
    /// code of 91. Implement the (static) DialingCodes.GetExistingDictionary() method to return the 
    /// pre-populated dictionary:
    /// </summary>
    public static Dictionary<int, string> GetExistingDictionary()
    {
        Dictionary<int, string> existingDict = new Dictionary<int, string>
        {
            [1] = "United States of America",
            [55] = "Brazil",
            [91] = "India"
        };
        return existingDict;
    }

    /// <summary>
    /// Implement the (static) method DialingCodes.AddCountryToEmptyDictionary() that creates a 
    /// dictionary and adds a dialing code and associated country name to it.
    /// </summary>
    public static Dictionary<int, string> AddCountryToEmptyDictionary(int countryCode, string countryName)
    {
        Dictionary<int,string> newDict = new Dictionary<int, string>();
        newDict.Add(countryCode,countryName);

        return newDict;
    }

    /// <summary>
    /// Implement the (static) method DialingCodes.AddCountryToExistingDictionary() that adds a dialing 
    /// code and associated country name to a non-empty dictionary.
    /// </summary>
    public static Dictionary<int, string> AddCountryToExistingDictionary(
        Dictionary<int, string> existingDictionary, int countryCode, string countryName)
    {
        existingDictionary.Add(countryCode, countryName);
        return existingDictionary;
    }

    /// <summary>
    /// Implement the (static) method DialingCodes.GetCountryNameFromDictionary() that takes a dialing
    /// code and returns the corresponding country name. If the dialing code is not contained in the
    /// dictionary then an empty string is returned.
    /// </summary>
    public static string GetCountryNameFromDictionary(
        Dictionary<int, string> existingDictionary, int countryCode)
    {
        string? value = "";
        if (existingDictionary.TryGetValue(countryCode, out value)) return value;
        return "";
    }

    /// <summary>
    /// Implement the (static) method DialingCodes.CheckCodeExists() to check whether a dialing code
    /// exists in the dictionary.
    /// </summary>
    public static bool CheckCodeExists(Dictionary<int, string> existingDictionary, int countryCode)
    {
        return existingDictionary.ContainsKey(countryCode);
    }

    /// <summary>
    /// Implement the (static) method DialingCodes.UpdateDictionary() which takes a dialing code and 
    /// replaces the corresponding country name in the dictionary with the country name passed as a 
    /// parameter. If the dialing code does not exist in the dictionary then the dictionary remains 
    /// unchanged.
    /// </summary>
    public static Dictionary<int, string> UpdateDictionary(
        Dictionary<int, string> existingDictionary, int countryCode, string countryName)
    {
        string? value = "";
        if (existingDictionary.TryGetValue(countryCode, out value))
            existingDictionary[countryCode] = countryName;
        
        return existingDictionary;
    }

    /// <summary>
    /// Implement the (static) method DialingCodes.RemoveCountryFromDictionary() that takes a dialing 
    /// code and will remove the corresponding record, dialing code + country name, from the dictionary.
    /// </summary>
    public static Dictionary<int, string> RemoveCountryFromDictionary(
        Dictionary<int, string> existingDictionary, int countryCode)
    {
        if (existingDictionary.ContainsKey(countryCode)) existingDictionary.Remove(countryCode);

        return existingDictionary;
    }

    /// <summary>
    /// Implement the (static) method DialingCodes.FindLongestCountryName() which will return the name of 
    /// the country with the longest name stored in the dictionary.
    /// </summary>
    public static string FindLongestCountryName(Dictionary<int, string> existingDictionary)
    {
        string longestName = "";
        foreach (int key in existingDictionary.Keys)
            if (existingDictionary[key].Length > longestName.Length)
                longestName = existingDictionary[key];

        return longestName;
    }
}