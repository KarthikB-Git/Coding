namespace LeetCodeTestbench.Solutions.P150_EvaluateReversePolishNotation;

// https://leetcode.com/problems/evaluate-reverse-polish-notation/
public class Solution
{
    public int EvalRpn(string[] tokens)
    {
        List<string> tokenList = [.. tokens];
        for (int i = 0; i < tokenList.Count; i++)
        {
            if (int.TryParse(tokenList[i], out var _)) continue;
            int res;
            if ("+" == tokenList[i]) res = int.Parse(tokenList[i - 2]) + int.Parse(tokenList[i - 1]);
            else if ("-" == tokenList[i]) res = int.Parse(tokenList[i - 2]) - int.Parse(tokenList[i - 1]);
            else if ("/" == tokenList[i]) res = int.Parse(tokenList[i - 2]) / int.Parse(tokenList[i - 1]);
            else res = int.Parse(tokenList[i - 2]) * int.Parse(tokenList[i - 1]);
            tokenList[i - 2] = res.ToString();
            tokenList.RemoveAt(i);
            tokenList.RemoveAt(i - 1);
            break;
        }

        var ans = int.Parse(tokenList[0]);
        return ans;
    }
}

