namespace LeetCodeTestbench.Solutions.P941_ValidMountainArray;

// https://leetcode.com/problems/valid-mountain-array/
// Difficulty: Easy
// Tags: Array
public class Solution
{
    public bool ValidMountainArray(int[] arr)
    {
        if (arr.Length < 3) return false;
        var i = 0;
        while (i + 1 < arr.Length && arr[i] < arr[i + 1]) i++;

        if (i == 0 || i == arr.Length - 1) return false;

        while (i + 1 < arr.Length && arr[i] > arr[i + 1]) i++;
        return i == arr.Length - 1;
    }
}

