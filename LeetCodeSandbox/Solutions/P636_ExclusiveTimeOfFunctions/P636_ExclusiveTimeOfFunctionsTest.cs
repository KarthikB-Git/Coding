using LeetCodeTestbench.Solutions.P636_ExclusiveTimeOfFunctions;
using Xunit.Abstractions;

namespace LeetCodeTestbench.Tests.P636_ExclusiveTimeOfFunctions;

public class SolutionTests(ITestOutputHelper output)
{
    private readonly Solution _sut = new();

    [Theory]
    [InlineData(2, new[] { "0:start:0","1:start:2","1:end:5","0:end:6" }, new[] { 3,4 })]
    [InlineData(1, new[] { "0:start:0","0:start:2","0:end:5","0:start:6","0:end:6","0:end:7" }, new[] { 8 })]
    [InlineData(2, new[] { "0:start:0","0:start:2","0:end:5","1:start:6","1:end:6","0:end:7" }, new[] { 7,1 })]
    public void ExclusiveTime_ReturnsExpectedResult(int n, IList<string> logs, int[] expected)
    {
        var actual = _sut.ExclusiveTime(n, logs);
        output.WriteLine($"Expected: [{string.Join(", ",expected)}]");
        output.WriteLine($"Actual: [{string.Join(", ",actual)}]");
        Assert.Equal(expected, actual);
    }
}
