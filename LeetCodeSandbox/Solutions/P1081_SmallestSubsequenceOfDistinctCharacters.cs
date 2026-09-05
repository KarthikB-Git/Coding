namespace LeetCodeTestbench.Solutions.P1081_SmallestSubsequenceOfDistinctCharacters;

// https://leetcode.com/problems/smallest-subsequence-of-distinct-characters/
// Difficulty: Medium
// Tags: String, Stack, Greedy, Monotonic Stack
// Note: this problem is the same as P316 Remove Duplicate Letters.
public class Solution
{
    public string SmallestSubsequence(string s)
    {
        var ans = new Stack<char>();
        var visited = new HashSet<char>();
        var lastIndex = new Dictionary<char, int>();
        for (var i = 0; i < s.Length; i++) lastIndex[s[i]] = i;
        
        for (var i = 0; i < s.Length; i++)
        {
            var c = s[i];
            if (visited.Contains(c)) continue;
            while (ans.Count > 0 && ans.Peek() > c && lastIndex[ans.Peek()] > i)
            {
                visited.Remove(ans.Pop());
            }
            ans.Push(c);
            visited.Add(c);
        }

        return new string(ans.Reverse().ToArray());
    }
}

