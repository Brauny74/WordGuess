using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class IListExtensions
{
    /// <summary>
    /// Shuffles the element order of the specified list.
    /// </summary>
    public static void Shuffle<T>(this IList<T> ts)
    {
        var count = ts.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i)
        {
            var r = Random.Range(i, count);
            var tmp = ts[i];
            ts[i] = ts[r];
            ts[r] = tmp;
        }
    }
}

public static class StringExtension
{
    /// <summary>
    /// Removes punctuation from the string
    /// </summary>
    public static string StripPunctuation(this string s)
    {
        string sb = "";
        foreach (char c in s)
        {
            if (!char.IsPunctuation(c) && c != '`')
                sb += c.ToString();
        }
        return sb;
    }

    /// <summary>
    /// Returns true, if the line contains any digits.
    /// </summary>
    public static bool ContainsDigits(this string s)
    {
        foreach (char c in s)
        {
            if (char.IsDigit(c))
                return true;
        }
        return false;
    }
}
