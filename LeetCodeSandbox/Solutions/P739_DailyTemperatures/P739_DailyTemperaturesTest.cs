using LeetCodeTestbench.Solutions.P739_DailyTemperatures;
using Xunit.Abstractions;

namespace LeetCodeTestbench.Tests.P739_DailyTemperatures;

public class SolutionTests(ITestOutputHelper output)
{
    private readonly Solution _sut = new();

    [Theory]
    [InlineData(new[] { 73,74,75,71,69,72,76,73 }, new[] { 1,1,4,2,1,1,0,0 })]
    [InlineData(new[] { 30,40,50,60 }, new[] { 1,1,1,0 })]
    [InlineData(new[] { 30,60,90 }, new[] { 1,1,0 })]
    public void DailyTemperatures_ReturnsExpectedResult(int[] temperatures, int[] expected)
    {
        var actual = _sut.DailyTemperatures(temperatures);
        output.WriteLine($"Expected: [{string.Join(", ", expected)}]");
        output.WriteLine($"Actual: [{string.Join(", ", actual)}]");
        Assert.Equal(expected, actual);
    }
}
