using LeetCodeTestbench.Solutions.P1470_ShuffleTheArray;

namespace LeetCodeTestbench.Tests.P1470_ShuffleTheArrayTest;

public class SolutionTests
{
    private readonly Solution _sut = new();

    [Theory]
    [InlineData(new[] { 2,5,1,3,4,7 }, 3, new[] { 2,3,5,4,1,7 })]
    [InlineData(new[] { 1,2,3,4,4,3,2,1 }, 4, new[] { 1,4,2,3,3,2,4,1 })]
    [InlineData(new[] { 1,1,2,2 }, 2, new[] { 1,2,1,2 })]
    public void Solution_ReturnsExpectedResult(int[] nums, int n, int[] expected)
    {
        var result = _sut.Shuffle(nums, n);
        Assert.Equal(expected, result);
    }
}
