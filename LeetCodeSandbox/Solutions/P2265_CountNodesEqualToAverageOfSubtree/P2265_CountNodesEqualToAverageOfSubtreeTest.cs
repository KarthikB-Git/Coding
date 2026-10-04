using LeetCodeTestbench.Common;
using LeetCodeTestbench.Solutions.P2265_CountNodesEqualToAverageOfSubtree;
using Xunit.Abstractions;

namespace LeetCodeTestbench.Tests.P2265_CountNodesEqualToAverageOfSubtree;

public class SolutionTests(ITestOutputHelper output)
{
    private readonly Solution _sut = new();

    public static IEnumerable<object?[]> TreeTestCases =>
        new List<object?[]>
        {
            // Example 1: root = [4,8,5,0,1,null,6], output = 5
            new object?[] { new int?[] { 4, 8, 5, 0, 1, null, 6 }, 5 },
            // Example 2: root = [1], output = 1
            new object?[] { new int?[] { 1 }, 1 },
            // Edge case: root = [0, null, 0], output = 2
            new object?[] { new int?[] { 0, null, 0 }, 2 }
        };

    [Theory]
    [MemberData(nameof(TreeTestCases))]
    public void AverageOfSubtree_ReturnsExpectedCount(int?[] treeNodes, int expected)
    {
        // Arrange
        var root = TestHelpers.BuildTree(treeNodes);

        // Act
        var actual = _sut.AverageOfSubtree(root);
        output.WriteLine($"Tree: [{string.Join(", ", treeNodes.Select(x => x?.ToString() ?? "null"))}]");
        output.WriteLine($"Expected Output: {expected}");
        output.WriteLine($"Actual Output: {actual}");

        // Assert
        Assert.Equal(expected, actual);
    }
}


