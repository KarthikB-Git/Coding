# 876. Middle of the Linked List

[Problem](https://leetcode.com/problems/middle-of-the-linked-list/) · Easy · Linked List, Two Pointers

## Approach

Advance a slow pointer by one node and a fast pointer by two nodes. When the fast pointer reaches the end, the slow pointer is at the middle; for an even-length list, this naturally selects the second middle node.

## Why it works

The fast pointer covers twice as many nodes as the slow pointer. Reaching the list end after two-speed traversal means the slow pointer has covered half the list.

## Complexity

- Time: `O(n)`.
- Space: `O(1)`.

See [the implementation](P876_MiddleOfTheLinkedList.cs).
