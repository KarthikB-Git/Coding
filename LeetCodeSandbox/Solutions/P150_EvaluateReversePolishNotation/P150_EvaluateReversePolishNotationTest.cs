using LeetCodeTestbench.Solutions.P150_EvaluateReversePolishNotation;
using Xunit.Abstractions;

namespace LeetCodeTestbench.Tests.P150_EvaluateReversePolishNotation;

public class SolutionTests(ITestOutputHelper output)
{
    private readonly Solution _sut = new();

    [Theory]
    [InlineData(new[] { "2","1","+","3","*" }, 9)]
    [InlineData(new[] { "4","13","5","/","+" }, 6)]
    [InlineData(new[] { "10","6","9","3","+","-11","*","/","*","17","+","5","+" }, 22)]
    public void EvalRPN_ReturnsExpectedResult(string[] tokens, int expected)
    {
        var actual = _sut.EvalRpn(tokens);
        output.WriteLine($"Expected Output: {expected}");
        output.WriteLine($"Actual Output: {actual}");
        Assert.Equal(expected, actual);
    }
}
