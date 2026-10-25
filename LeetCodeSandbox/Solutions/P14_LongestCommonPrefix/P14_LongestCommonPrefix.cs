using LeetCodeTestbench.Common;

namespace LeetCodeTestbench.Solutions.P14_LongestCommonPrefix;

// https://leetcode.com/problems/longest-common-prefix/
// Difficulty: Easy
// Tags: Array, String, Trie
[Problem(14, "Longest Common Prefix", Difficulty.Easy, Topic.Array, Topic.String, Topic.Trie)]
public class Solution
{
    public string LongestCommonPrefix(string[] strs)
    {
        var pref = "";
        var minLength = strs[0].Length;
        minLength = strs.Select(s => s.Length).Prepend(minLength).Min();
        for (var i = 0; i < minLength; i++)
        {
            var j = 0;
            var tru = true;
            var car = strs[j][i];
            while (j < strs.Length)
            {
                if (strs[j][i] != car)
                {
                    tru = false;
                    break;
                }
                j++;
            }
            if (tru)
            {
                pref += car;
            }
            else break;
        }
        return pref;
    }
}

