using LeetCodeTestbench.Common;

namespace LeetCodeTestbench.Solutions.P1700_NumberOfStudentsUnableToEatLunch;

// https://leetcode.com/problems/number-of-students-unable-to-eat-lunch/
// Difficulty: Easy
// Tags: Array, Stack, Queue, Simulation
[Problem(1700, "Number Of Students Unable To Eat Lunch", Difficulty.Easy, Topic.Array, Topic.Stack, Topic.Queue, Topic.Simulation)]
public class Solution
{
    public int CountStudents(int[] students, int[] sandwiches)
    {
        var qStuds = new Queue<int>(students);
        var sLunch = new Stack<int>(sandwiches.Reverse());
        var rotations = 0;
        while (qStuds.Count > 0 && rotations < qStuds.Count)
        {
            if (sLunch.Peek() == qStuds.Peek())
            {
                sLunch.Pop();
                qStuds.Dequeue();
                rotations = 0;
            }
            else
            {
                qStuds.Enqueue(qStuds.Dequeue());
                rotations++;
            }
        }
        return qStuds.Count;
    }
}

