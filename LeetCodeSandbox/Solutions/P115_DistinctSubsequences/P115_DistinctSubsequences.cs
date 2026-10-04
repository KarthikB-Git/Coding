using LeetCodeTestbench.Common;

namespace LeetCodeTestbench.Solutions.P115_DistinctSubsequences;

// https://leetcode.com/problems/distinct-subsequences/
// Difficulty: Hard
// Tags: String, Dynamic Programming
[Problem(115, "Distinct Subsequences", Difficulty.Hard, Topic.String, Topic.DynamicProgramming)]
public class Solution
{
    public int NumDistinct(string s, string t)
    {
        int m = s.Length, n = t.Length;
        if (n == 0) return 1;
        if (n > m) return 0;
        var ans = new int[m + 1, n + 1];
        for (var i = 0; i <= m; i++) ans[i, 0] = 1;
        for (var j = 1; j <= n; j++) ans[0, j] = 0;
        for (var i = 1; i <= m; i++)
        {
            for (var j = 1; j <= n; j++)
            {
                if (s[i - 1] == t[j - 1]) ans[i, j] = ans[i - 1, j - 1] + ans[i - 1, j];
                else ans[i, j] = ans[i - 1, j];
            }
        }
        return ans[m, n];
    }
}

