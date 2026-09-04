using LeetCodeTestbench.Solutions.P84_LargestRectangleInHistogram;
using Xunit.Abstractions;

namespace LeetCodeTestbench.Tests.P84_LargestRectangleInHistogram;

public class SolutionTests(ITestOutputHelper output)
{
    private readonly Solution _sut = new();

    [Theory]
    [InlineData(new[] { 2,1,5,6,2,3 }, 10)]
    [InlineData(new[] { 2,4 }, 4)]
    public void LargestRectangleArea_ReturnsExpectedResult(int[] heights, int expected)
    {
        var actual = _sut.LargestRectangleArea(heights);
        output.WriteLine($"Expected Output: {expected}");
        output.WriteLine($"Actual Output: {actual}");
        Assert.Equal(expected, actual);
    }
}
