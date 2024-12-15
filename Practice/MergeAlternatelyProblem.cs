using System.Text;

namespace ArxPractice;


/// <summary>
/// You are given two strings word1 and word2. Merge the strings by adding letters in alternating order, starting with word1.
/// If a string is longer than the other, append the additional letters onto the end of the merged string.
/// Return the merged string.
///
/// <a href="https://leetcode.com/problems/merge-strings-alternately/description/?envType=study-plan-v2&envId=leetcode-75">MergeAlternately</a>.
///
/// Input: word1 = "abc", word2 = "pqr"
///    Output: "apbqcr"
///    Explanation: The merged string will be merged as so:
///    word1:  a b   c
///    word2:    p q   r
///    merged: a p b q c r
/// </summary>
internal class MergeAlternatelyProblem
{
    public string MergeAlternately(string word1, string word2)
    {
        var result = new StringBuilder
        {
            Capacity = 0,
            Length = 0
        };
        
        var length = Math.Max(word1.Length, word2.Length);
        for (var i = 0; i < length; i++)
        {
            if (i < word1.Length)
            {
                result.Append(word1[i]);
            }
            if (i < word2.Length)
            {
                result.Append(word2[i]);
            }
        }
        return result.ToString();
    }
}
