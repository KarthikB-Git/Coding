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
                var b = stack.Pop();
                var a = stack.Pop();
                var res = t switch
                {
                    "+" => a + b,
                    "-" => a - b,
                    "/" => a / b,
                    _ => a * b
                };
                stack.Push(res);
            }
        }
        return stack.Pop();
    }
}

