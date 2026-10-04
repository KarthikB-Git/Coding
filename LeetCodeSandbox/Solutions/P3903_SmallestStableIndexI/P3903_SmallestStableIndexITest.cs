using LeetCodeTestbench.Solutions.P3903_SmallestStableIndexI;
using Xunit.Abstractions;

namespace LeetCodeTestbench.Tests.P3903_SmallestStableIndexI;

public class SolutionTests (ITestOutputHelper output)
{
    private readonly Solution _sut = new();

    [Theory]
    [InlineData(new[] { 5,0,1,4 }, 3, 3)]
    [InlineData(new[] { 3,2,1 }, 1, -1)]
    [InlineData(new[] { 0 }, 0, 0)]
    public void FirstStableIndex_ReturnsExpectedResult(int[] nums, int k, int expected)
    {
        var actual = _sut.FirstStableIndex(nums, k);
        output.WriteLine($"Expected Output: {expected}");
        output.WriteLine($"Actual Output: {actual}");
        Assert.Equal(expected, actual);
    }
}
