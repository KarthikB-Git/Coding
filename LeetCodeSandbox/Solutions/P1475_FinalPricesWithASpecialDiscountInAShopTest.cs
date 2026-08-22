using LeetCodeTestbench.Solutions.P1475_FinalPricesWithASpecialDiscountInAShop;
using Xunit.Abstractions;

namespace LeetCodeTestbench.Tests.P1475_FinalPricesWithASpecialDiscountInAShop;

public class SolutionTests(ITestOutputHelper output)
{
    private readonly Solution _sut = new();

    [Theory]
    [InlineData(new[] { 8,4,6,2,3 }, new[] { 4,2,4,2,3 })]
    [InlineData(new[] { 1,2,3,4,5 }, new[] { 1,2,3,4,5 })]
    [InlineData(new[] { 10,1,1,6 }, new[] { 9,0,1,6 })]
    public void FinalPrices_ReturnsExpectedResult(int[] prices, int[] expected)
    {
        var actual = _sut.FinalPrices(prices);
        output.WriteLine($"Expected: [{string.Join(", ",expected)}]");
        output.WriteLine($"Actual: [{string.Join(", ",actual)}]");
        Assert.Equal(expected, actual);
    }
}
