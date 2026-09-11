using LeetCodeTestbench.Common;

namespace LeetCodeTestbench.Solutions.P3483_Unique3DigitEvenNumbers;

// https://leetcode.com/problems/unique-3-digit-even-numbers/
// Difficulty: Easy
// Tags: Array, Hash Table, Recursion, Enumeration
[Problem(3483, "Unique 3-Digit Even Numbers", Difficulty.Easy, Topic.Array, Topic.HashTable, Topic.Recursion, Topic.Enumeration, Topic.Other)]
public class Solution
{
    public int TotalNumbers(int[] digits) {
        var ans = 0;
        HashSet<int> hash = [];
        var n = digits.Length;
        for (var i = 0; i < n; i++)
        {
            if (digits[i] == 0) continue;
            for (var j = 0; j < n; j++)
            {
                if (i == j) continue;
                for (var k = 0; k < n; k++)
                {
                    if (k == i || k == j || digits[k] % 2 != 0) continue;
                    var num = digits[i] * 100 + digits[j] * 10 + digits[k];
                    if (hash.Add(num)) ans++;
                }
            }
        }
        return ans;
    }
}

