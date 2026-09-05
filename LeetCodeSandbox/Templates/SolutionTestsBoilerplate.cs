using LeetCodeTestbench.Solutions.PXXXX_ProblemName;
using Xunit.Abstractions;

namespace LeetCodeTestbench.Tests.PXXXX_ProblemName;

public class SolutionTests (ITestOutputHelper output)
{
    private readonly Solution _sut = new();

    // Example 1: Testing primitive/array inputs
    [Theory]
    [InlineData(new[] { 2, 7, 11, 15 }, 9, new[] { 0, 1 })]
    public void Solution_ReturnsExpectedResult(int[] nums, int target, int[] expected)
    {
        // Act
        // var actual = _sut.TwoSum(nums, target);
        // output.WriteLine($"Expected Output: [{string.Join(", ", expected)}]");
        // output.WriteLine($"Actual Output: [{string.Join(", ", actual)}]");

        // Assert
        // Assert.Equal(expected, actual);
    }

    // Example 2: Testing ListNode (Linked List) inputs with TestHelpers
    // [Fact]
    // public void Solution_LinkedListExample()
    // {
    //     var head = TestHelpers.BuildList(1, 2, 4);
    //     var expected = new[] { 1, 2, 4 };
    //     
    //     var resultNode = _sut.SomeLinkedListMethod(head);
    //     
    //     Assert.Equal(expected, TestHelpers.ToArray(resultNode));
    // }

    // Example 3: Testing TreeNode (Binary Tree) inputs with TestHelpers
    // [Fact]
    // public void Solution_BinaryTreeExample()
    // {
    //     var root = TestHelpers.BuildTree(3, 9, 20, null, null, 15, 7);
    //     
    //     var result = _sut.SomeTreeMethod(root);
    //     
    //     Assert.Equal(3, result);
    // }
}
