namespace LeetCodeTestbench.Solutions.P1700_NumberOfStudentsUnableToEatLunch;

// https://leetcode.com/problems/number-of-students-unable-to-eat-lunch/
// Difficulty: Easy
// Tags: Array, Stack, Queue, Simulation
public class Solution
{
    public int CountStudents(int[] students, int[] sandwiches)
    {
        var rem = new int[2];
        foreach (var s in students) rem[s]++;

        foreach (var lunch in sandwiches)
        {
            if (rem[lunch] == 0)
            {
                break;
            }
            rem[lunch]--;
        }

        return rem.Sum();
    }
}

