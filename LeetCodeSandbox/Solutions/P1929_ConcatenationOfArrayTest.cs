using LeetCodeTestbench.Solutions.P1929_ConcatenationOfArray;
using Xunit;

namespace LeetCodeTestbench.Tests.P1929_ConcatenationOfArrayTest;

public class SolutionTests
{
    private readonly Solution _sut = new();

    [Theory]
    [InlineData(new[] { 1, 2, 1}, new[] { 1, 2, 1, 1, 2, 1 })]
    [InlineData(new[] { 1,3,2,1 }, new[] { 1,3,2,1,1,3,2,1 })]
    [InlineData(new[] { 3, 3 }, new[] { 3, 3, 3, 3 })]
    public void GetConcatenation_ReturnsExpectedArray(int[] nums, int[] expected)
    {
        var result = _sut.GetConcatenation(nums);
        Assert.Equal(expected, result);
    }
}
