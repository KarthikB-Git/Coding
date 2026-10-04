# 2265. Count Nodes Equal to Average of Subtree

[Problem](https://leetcode.com/problems/count-nodes-equal-to-average-of-subtree/) · Medium · Tree, DFS

## Approach

Perform post-order DFS. Each call returns its subtree's sum and node count. After combining left and right results with the current node, compare integer `sum / count` with the node value and increment the answer when equal.

## Why it works

Post-order traversal guarantees both child aggregates are available before evaluating a node. Their sums and counts form the exact aggregate of that node's subtree, so each average comparison is correct and each node is visited once.

## Complexity

- Time: `O(n)`.
- Space: `O(h)` recursion stack, where `h` is tree height.

See [the implementation](P2265_CountNodesEqualToAverageOfSubtree.cs).
