using LeetCodeTestbench.Common;

namespace LeetCodeTestbench.Solutions.P835_ImageOverlap;

// https://leetcode.com/problems/image-overlap/
// Difficulty: Medium
// Tags: Array, Matrix
[Problem(835, "Image Overlap", Difficulty.Medium, Topic.Array, Topic.Matrix)]
public class Solution
{
    public int LargestOverlap(int[][] img1, int[][] img2) {
        Dictionary<(int dr, int dc),int> shift = new();
        var n = img1.Length;
        var ones1 = new List<(int r, int c)>();
        var ones2 = new List<(int r, int c)>();
        for (var r = 0; r < n; r++)
        {
            for (var c = 0; c < n; c++)
            {
                if(img1[r][c] == 1) ones1.Add((r,c));
                if(img2[r][c] == 1) ones2.Add((r,c));
            }
        }
        if (ones1.Count == 0) return 0;
        int ans = 0;
        foreach (var curr in from p1 in ones1 from p2 in ones2 select (dr: p2.r - p1.r, dc: p2.c - p1.c))
        {
            shift[curr] = shift.GetValueOrDefault(curr, 0) + 1;
            ans = Math.Max(ans, shift[curr]);
        }
        return ans;
    }
}

