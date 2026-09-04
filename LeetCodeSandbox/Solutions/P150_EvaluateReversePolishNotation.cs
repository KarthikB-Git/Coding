namespace LeetCodeTestbench.Solutions.P150_EvaluateReversePolishNotation;

// https://leetcode.com/problems/evaluate-reverse-polish-notation/
// Difficulty: Medium
// Tags: Array, Math, Stack
public class Solution
{
    public int EvalRpn(string[] tokens)
    {
        Stack<int> stack = [];
        foreach (var t in tokens)
        {
            if (int.TryParse(t, out var val))
            {
                stack.Push(val);
            }
            else
            {
                int res;
                var b = stack.Pop();
                var a = stack.Pop();
                if (t == "+") res = a + b;
                else if (t == "-") res = a - b;
                else if (t == "/") res = a / b;
                else res = a * b;
                stack.Push(res);
            }
        }
        return stack.Pop();
    }
}

