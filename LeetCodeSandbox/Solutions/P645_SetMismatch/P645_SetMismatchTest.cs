using LeetCodeTestbench.Solutions.P645_SetMismatch;

namespace LeetCodeTestbench.Tests.P645_SetMismatch;

public class SolutionTests
{
    private readonly Solution _sut = new();

    [Theory]
    [InlineData(new[] { 1, 2, 2, 4 }, new[] { 2, 3 })]
    [InlineData(new[] { 1, 1 }, new[] { 1, 2 })]
    [InlineData(new[] { 2, 2 }, new[] { 2, 1 })]
    public void Solution_ReturnsExpectedResult(int[] nums, int[] expected)
    {
        // Act
        var actual = _sut.FindErrorNums(nums);

        // Assert
        Assert.Equal(expected, actual);
    }
}

