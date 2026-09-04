namespace LeetCodeTestbench.Solutions.P636_ExclusiveTimeOfFunctions;

// https://leetcode.com/problems/exclusive-time-of-functions/
// Difficulty: Medium
// Tags: Array, Stack
public class Solution
{
    public int[] ExclusiveTime(int n, IList<string> logs)
    {
        var ans = new int[n];
        Stack<int> call = new Stack<int>();
        var lastLogTimeStamp = -1;
        foreach (var log in logs)
        {
            var timeStamp = int.Parse(log.Split(":")[2]);
            if (log.Split(":")[1] != "start") timeStamp += 1;

            if (call.Count > 0)
            {
                ans[call.Peek()] += timeStamp - lastLogTimeStamp;
            }

            if (log.Split(":")[1] == "start")
            {
                call.Push(int.Parse(log.Split(":")[0]));
            }
            else
            {
                call.Pop();
            }
            lastLogTimeStamp = timeStamp;
        }
        return ans;
    }
}

