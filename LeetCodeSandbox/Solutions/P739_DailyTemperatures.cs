namespace LeetCodeTestbench.Solutions.P739_DailyTemperatures;

// https://leetcode.com/problems/daily-temperatures/
public class Solution
{
    public int[] DailyTemperatures(int[] temperatures)
    {
        int[] ans = new int[temperatures.Length];
        for(int i=0;i<temperatures.Length;i++)
        {
            for (int j = i + 1; j < temperatures.Length; j++)
            {
                if (temperatures[i] < temperatures[j])
                {
                    ans[i] = j - i;
                    break;
                }
            }
        }
        return ans;
    }
}

