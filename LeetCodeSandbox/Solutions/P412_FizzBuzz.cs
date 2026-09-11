using LeetCodeTestbench.Common;

namespace LeetCodeTestbench.Solutions.P412_FizzBuzz;

// https://leetcode.com/problems/fizz-buzz/
// Difficulty: Easy
// Tags: Math, String, Simulation
[Problem(412, "Fizz Buzz", Difficulty.Easy, Topic.Math, Topic.String, Topic.Simulation)]
public class Solution
{
    public IList<string> FizzBuzz(int n)
    {
        var ans = new List<string> { "1" };
        if (n > 1) ans.Add("2");
        for (var i = 3; i <= n; i++)
        {
            var ele = "";
            if (i % 3 == 0)
            {
                ele += "Fizz";
            }
            if (i % 5 == 0)
            {
                ele += "Buzz";
            }
            if (i % 3 != 0 && i % 5 != 0)
            {
                ele = i.ToString();
            }
            ans.Add(ele);
        }
        return ans;
    }
}

