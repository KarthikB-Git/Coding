using LeetCodeTestbench.Solutions.P316_RemoveDuplicateLetters;
using Xunit.Abstractions;

namespace LeetCodeTestbench.Tests.P316_RemoveDuplicateLetters;

public class SolutionTests (ITestOutputHelper output)
{
    private readonly Solution _sut = new();

    [Theory]
    [InlineData("bcabc", "abc")]
    [InlineData("cbacdcbc", "acdb")]
    public void RemoveDuplicateLetters_ReturnsExpectedResult(string s, string expected)
    {
        var actual = _sut.RemoveDuplicateLetters(s);
        output.WriteLine($"Expected Output: {expected}");
        output.WriteLine($"Actual Output: {actual}");
        Assert.Equal(expected, actual);
    }
}
