using LeetCodeTestbench.Solutions.P383_RansomNote;
using Xunit.Abstractions;

namespace LeetCodeTestbench.Tests.P383_RansomNote;

public class SolutionTests (ITestOutputHelper output)
{
    private readonly Solution _sut = new();

    [Theory]
    [InlineData("a", "b", false)]
    [InlineData("aa", "ab", false)]
    [InlineData("aa", "aab", true)]
    public void CanConstruct_ReturnsExpectedResult(string ransomNote, string magazine, bool expected)
    {
        var actual = _sut.CanConstruct(ransomNote, magazine);
        output.WriteLine($"Expected Output: {expected}");
        output.WriteLine($"Actual Output: {actual}");
        Assert.Equal(expected, actual);
    }
}
