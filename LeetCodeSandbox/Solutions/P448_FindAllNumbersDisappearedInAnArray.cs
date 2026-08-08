namespace LeetCodeTestbench.Solutions.P448_FindAllNumbersDisappearedInAnArray;

// https://leetcode.com/problems/find-all-numbers-disappeared-in-an-array
public class Solution
{
    public IList<int> FindDisappearedNumbers(int[] nums)
    {
        List<int> ans = [.. nums];
        for (int i = 1; i <= nums.Length; i++)
        {
            if (ans.Contains(i))
            {
                ans.RemoveAll(j => j == i);
            }
            else
            {
                ans.Add(i);
            }
        }

        return ans;
    }
}

