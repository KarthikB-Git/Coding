using LeetCodeTestbench.Solutions.P485_MaxConsecutiveOnes;
using Xunit;

namespace LeetCodeTestbench.Tests.P485_MaxConsecutiveOnesTest;

public class SolutionTests
{
    private readonly Solution _sut = new();

    [Theory]
    [InlineData(new[] { 1, 1, 0, 1, 1, 1 }, 3)]
    [InlineData(new[] { 1, 0, 1, 1, 0, 1 }, 2)]
    public void FindMaxConsec1ReturnsNum(int[] nums, int expected)
    {
        var result = _sut.FindMaxConsecutiveOnes(nums);
        Assert.Equal(expected, result);
    }
}
