using LeetCodeTestbench.Common;

namespace LeetCodeTestbench.Solutions.P1342_NumberOfStepsToReduceANumberToZero;

// https://leetcode.com/problems/number-of-steps-to-reduce-a-number-to-zero/
// Difficulty: Easy
// Tags: Math, Bit Manipulation
[Problem(1342, "Number Of Steps To Reduce ANumber To Zero", Difficulty.Easy, Topic.Math, Topic.BitManipulation)]
public class Solution
{
    public int NumberOfSteps(int num)
    {
        var ans = 0;
        while (num > 0)
        {
            num = (num & 1) == 0 ? num >> 1 : num - 1;
            ans++;
        }
        return ans;
    }
}

