using LeetCodeTestbench.Solutions.P3483_Unique3DigitEvenNumbers;
using Xunit.Abstractions;

namespace LeetCodeTestbench.Tests.P3483_Unique3DigitEvenNumbers;

public class SolutionTests (ITestOutputHelper output)
{
    private readonly Solution _sut = new();

    [Theory]
    [InlineData(new[] { 1,2,3,4 }, 12)]
    [InlineData(new[] { 0,2,2 }, 2)]
    [InlineData(new[] { 6,6,6 }, 1)]
    [InlineData(new[] { 1,3,5 }, 0)]
    public void TotalNumbers_ReturnsExpectedResult(int[] digits, int expected)
    {
        var actual = _sut.TotalNumbers(digits);
        output.WriteLine($"Expected Output: {expected}");
        output.WriteLine($"Actual Output: {actual}");
        Assert.Equal(expected, actual);
    }
}
