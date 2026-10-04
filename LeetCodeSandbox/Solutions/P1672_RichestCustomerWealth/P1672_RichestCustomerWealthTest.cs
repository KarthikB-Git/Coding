using LeetCodeTestbench.Solutions.P1672_RichestCustomerWealth;
using Xunit.Abstractions;

namespace LeetCodeTestbench.Tests.P1672_RichestCustomerWealth;

public class SolutionTests (ITestOutputHelper output)
{
    private readonly Solution _sut = new();

    public static TheoryData<int[][], int> TestCases => new()
    {
        { new[] { new[] { 1,2,3 }, new[] { 3,2,1 } }, 6 },
        { new[] { new[] { 1,5 }, new[] { 7,3 }, new[] { 3,5 } }, 10 },
        { new[] { new[] { 2,8,7 }, new[] { 7,1,3 }, new[] { 1,9,5 } }, 17 },
    };

    [Theory]
    [MemberData(nameof(TestCases))]
    public void MaximumWealth_ReturnsExpectedResult(int[][] accounts, int expected)
    {
        var actual = _sut.MaximumWealth(accounts);
        output.WriteLine($"Expected Output: {expected}");
        output.WriteLine($"Actual Output: {actual}");
        Assert.Equal(expected, actual);
    }
}
