using LeetCodeTestbench.Solutions.P1365_HowManyNumbersAreSmallerThanTheCurrentNumber;

namespace LeetCodeTestbench.Tests.P1365_HowManyNumbersAreSmallerThanTheCurrentNumber;

public class SolutionTests
{
    private readonly Solution _sut = new();

    // Example 1: Testing primitive/array inputs
    [Theory]
    [InlineData(new[] { 8, 1, 2, 2, 3 }, new[] { 4, 0, 1, 1, 3 })]
    [InlineData(new[] { 6, 5, 4, 8 }, new[] { 2, 1, 0, 3 })]
    [InlineData(new[] { 7, 7, 7, 7 }, new[] { 0, 0, 0, 0 })]
    public void Solution_ReturnsExpectedResult(int[] nums, int[] expected)
    {
        var actual = _sut.SmallerNumbersThanCurrent(nums);

        Assert.Equal(expected, actual);
    }
}

