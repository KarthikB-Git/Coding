using LeetCodeTestbench.Solutions.P0001_TwoSum;
using Xunit;

namespace LeetCodeTestbench.Tests.P0001_TwoSum;

public class SolutionTests
{
    private readonly Solution _sut = new();

    [Theory]
    [InlineData(new[] { 2, 7, 11, 15 }, 9, new[] { 0, 1 })]
    [InlineData(new[] { 3, 2, 4 }, 6, new[] { 1, 2 })]
    [InlineData(new[] { 3, 3 }, 6, new[] { 0, 1 })]
    public void TwoSum_ReturnsExpectedIndices(int[] nums, int target, int[] expected)
    {
        var result = _sut.TwoSum(nums, target);
        Assert.Equal(expected, result);
    }
}
