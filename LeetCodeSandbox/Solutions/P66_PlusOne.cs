namespace LeetCodeTestbench.Solutions.P66_PlusOne;

// https://leetcode.com/problems/plus-one/
// Difficulty: Easy
// Tags: Array, Math
public class Solution
{
    public int[] PlusOne(int[] digits)
    {
        for (var i = digits.Length - 1; i >= 0; i--)
        {
            if (digits[i] < 9)
            {
                digits[i]++;
                return digits;
            }
            digits[i] = 0;
        }
        var result = new int[digits.Length + 1];
        result[0] = 1;
        return result;
    }
}

