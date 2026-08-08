using LeetCodeTestbench.Solutions.P448_FindAllNumbersDisappearedInAnArray;

namespace LeetCodeTestbench.Tests.P448_FindAllNumbersDisappearedInAnArray;

public class SolutionTests
{
    private readonly Solution _sut = new();

    // Example 1: Testing primitive/array inputs
    [Theory]
    [InlineData(new[] { 4, 3, 2, 7, 8, 2, 3, 1 }, new[] { 5, 6 })]
    [InlineData(new[] { 1, 1 }, new[] { 2 })]
    public void Solution_ReturnsExpectedResult(int[] nums, int[] expected)
    {
        // Act
        var actual = _sut.FindDisappearedNumbers(nums);

        // Assert
        Assert.Equal(expected, actual);
    }
}

