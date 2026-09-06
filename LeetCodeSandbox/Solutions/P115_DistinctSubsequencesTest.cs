using LeetCodeTestbench.Solutions.P115_DistinctSubsequences;
using Xunit.Abstractions;

namespace LeetCodeTestbench.Tests.P115_DistinctSubsequences;

public class SolutionTests (ITestOutputHelper output)
{
    private readonly Solution _sut = new();

    [Theory]
    [InlineData("rabbbit", "rabbit", 3)]
    [InlineData("babgbag", "bag", 5)]
    public void NumDistinct_ReturnsExpectedResult(string s, string t, int expected)
    {
        var actual = _sut.NumDistinct(s, t);
        output.WriteLine($"Expected Output: {expected}");
        output.WriteLine($"Actual Output: {actual}");
        Assert.Equal(expected, actual);
    }
}
