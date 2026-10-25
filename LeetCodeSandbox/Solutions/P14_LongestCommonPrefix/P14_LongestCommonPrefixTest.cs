using LeetCodeTestbench.Solutions.P14_LongestCommonPrefix;
using Xunit.Abstractions;

namespace LeetCodeTestbench.Tests.P14_LongestCommonPrefix;

public class SolutionTests (ITestOutputHelper output)
{
    private readonly Solution _sut = new();

    [Theory]
    [InlineData(new[] { "flower","flow","flight" }, "fl")]
    [InlineData(new[] { "dog","racecar","car" }, "")]
    public void LongestCommonPrefix_ReturnsExpectedResult(string[] strs, string expected)
    {
        var actual = _sut.LongestCommonPrefix(strs);
        output.WriteLine($"Expected Output: {expected}");
        output.WriteLine($"Actual Output: {actual}");
        Assert.Equal(expected, actual);
    }
}
