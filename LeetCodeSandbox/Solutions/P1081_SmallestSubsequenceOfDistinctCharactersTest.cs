using LeetCodeTestbench.Solutions.P1081_SmallestSubsequenceOfDistinctCharacters;
using Xunit.Abstractions;

namespace LeetCodeTestbench.Tests.P1081_SmallestSubsequenceOfDistinctCharacters;

public class SolutionTests (ITestOutputHelper output)
{
    private readonly Solution _sut = new();

    [Theory]
    [InlineData("bcabc", "abc")]
    [InlineData("cbacdcbc", "acdb")]
    public void SmallestSubsequence_ReturnsExpectedResult(string s, string expected)
    {
        var actual = _sut.SmallestSubsequence(s);
        output.WriteLine($"Expected Output: {expected}");
        output.WriteLine($"Actual Output: {actual}");
        Assert.Equal(expected, actual);
    }
}
