using LeetCodeTestbench.Common;

namespace LeetCodeTestbench.Solutions.P1441_BuildAnArrayWithStackOperations;

// https://leetcode.com/problems/build-an-array-with-stack-operations/
// Difficulty: Medium
// Tags: Array, Stack, Simulation
[Problem(1441, "Build An Array With Stack Operations", Difficulty.Medium, Topic.Array, Topic.Stack, Topic.Simulation)]
public class Solution
{
    public IList<string> BuildArray(int[] target, int n)
    {
        List<string> ans = [];
        var currStream = 1;
        foreach (var tar in target)
        {
            while (currStream < tar)
            {
                ans.Add("Push");
                ans.Add("Pop");
                currStream++;
            }
            ans.Add("Push");
            currStream++;
        }
        return ans;
    }
}

