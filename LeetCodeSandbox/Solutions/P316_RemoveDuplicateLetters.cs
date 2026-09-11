using LeetCodeTestbench.Common;

namespace LeetCodeTestbench.Solutions.P316_RemoveDuplicateLetters;

// https://leetcode.com/problems/remove-duplicate-letters/
// Difficulty: Medium
// Tags: String, Stack, Greedy, Monotonic Stack
[Problem(316, "Remove Duplicate Letters", Difficulty.Medium, Topic.String, Topic.Stack, Topic.Greedy, Topic.MonotonicStack)]
public class Solution
{
    public string RemoveDuplicateLetters(string s)
    {
        var lastIndex = new int[26];
        var ans = new Stack<char>();
        var seen = new bool[26];
        for (var i = 0; i < s.Length; i++)
        {
            lastIndex[s[i] - 'a'] = i;
        }

        for (var i = 0; i < s.Length; i++)
        {
            var curr = s[i];
            if (seen[curr - 'a']) continue;
            while (ans.Count > 0 && curr < ans.Peek() && i < lastIndex[ans.Peek() - 'a'])
            {
                seen[ans.Pop() - 'a'] = false;
            }
            ans.Push(curr);
            seen[curr - 'a'] = true;
        }

        return new string(ans.Reverse().ToArray());
    }
}