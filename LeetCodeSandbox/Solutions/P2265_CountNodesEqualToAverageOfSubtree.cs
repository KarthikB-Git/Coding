using LeetCodeTestbench.Common;

namespace LeetCodeTestbench.Solutions.P2265_CountNodesEqualToAverageOfSubtree;

// https://leetcode.com/problems/count-nodes-equal-to-average-of-subtree/
// Difficulty: Medium
// Tags: Tree, Depth-First Search, Binary Tree
[Problem(2265, "Count Nodes Equal to Average of Subtree", Difficulty.Medium, Topic.Tree, Topic.DepthFirstSearch, Topic.BinaryTree)]
public class Solution {
    public int AverageOfSubtree(TreeNode? root)
    {
        int ans = 0;
        Dfs(root);
        return ans;

        (int sum, int value) Dfs(TreeNode? node)
        {
            if (node == null) return (0, 0);

            var (leftSum, leftNodes) = Dfs(node.Left);
            var (rightSum, rightNodes) = Dfs(node.Right);

            var totalSum = leftSum + rightSum + node.Val;
            var totalNodes = leftNodes + rightNodes + 1;

            if (totalSum / totalNodes == node.Val) ans++;

            return (totalSum, totalNodes);
        }
    }
}


