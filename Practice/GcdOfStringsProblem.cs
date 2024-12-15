using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArxPractice;


/// <summary>
/// we are looking for the Greatest Common Divisor of two strings, which for convenience we will consider as the GCD string. To remove ambiguity, here we regard:
/// all strings that divides both str1 and str2 as divisible strings.
/// the longest string among all divisible strings as the GCD string.
/// Example 1:
///    Input: str1 = "ABCABC", str2 = "ABC"
///    Output: "ABC"
/// Example 2:
///    
///    Input: str1 = "ABABAB", str2 = "ABAB"
///    Output: "AB"
/// Example 3:
///    
///    Input: str1 = "LEET", str2 = "CODE"
///    Output: ""
/// </summary>
internal class GcdOfStringsProblem
{
    private bool Valid(string str1, string str2, int k)
    {
        int len1 = str1.Length, len2 = str2.Length;
        if (len1 % k > 0 || len2 % k > 0)
        {
            return false;
        }
        else
        {
            string baseStr = str1.Substring(0, k);
            return str1.Replace(baseStr, "").Length == 0 && str2.Replace(baseStr, "").Length == 0;
        }
    }

    public string GcdOfStrings(string str1, string str2)
    {
        int len1 = str1.Length, len2 = str2.Length;
        for (int i = Math.Min(len1, len2); i >= 1; --i)
        {
            if (Valid(str1, str2, i))
            {
                return str1.Substring(0, i);
            }
        }
        return "";
    }
}
