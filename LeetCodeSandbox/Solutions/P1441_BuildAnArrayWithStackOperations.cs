namespace LeetCodeTestbench.Solutions.P1441_BuildAnArrayWithStackOperations;

// https://leetcode.com/problems/build-an-array-with-stack-operations/
public class Solution
{
    public IList<string> BuildArray(int[] target, int n)
    {
        List<string> ans = [];
        int currStream = 1;
        foreach (int tar in target)
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

