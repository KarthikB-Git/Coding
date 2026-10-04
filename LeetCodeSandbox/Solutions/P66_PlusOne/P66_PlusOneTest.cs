using LeetCodeTestbench.Solutions.P66_PlusOne;

namespace LeetCodeTestbench.Tests.P66_PlusOne;

public class SolutionTests
{
    private readonly Solution _sut = new();

    [Theory]
    [InlineData(new[] { 1,2,3 }, new[] { 1,2,4 })]
    [InlineData(new[] { 4,3,2,1 }, new[] { 4,3,2,2 })]
    [InlineData(new[] { 9 }, new[] { 1,0 })]
    public void PlusOne_ReturnsExpectedResult(int[] digits, int[] expected)
    {
        var actual = _sut.PlusOne(digits);
        Assert.Equal(expected, actual);
    }
}
