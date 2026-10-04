# 1081. Smallest Subsequence of Distinct Characters

[Problem](https://leetcode.com/problems/smallest-subsequence-of-distinct-characters/) · Medium · Greedy, Monotonic Stack

## Approach

Track each character's last index, then build a stack containing each character once. Skip characters already selected. For a new character, remove larger stack characters only when they appear again later; push the new character afterward.

## Why it works

At every step the stack is the lexicographically smallest feasible prefix. Removing a larger character improves that prefix, and the last-index condition ensures it remains available for later inclusion. This is the same greedy strategy as problem 316.

## Complexity

- Time: `O(n)`.
- Space: `O(k)`, where `k` is the number of distinct characters.

See [the implementation](P1081_SmallestSubsequenceOfDistinctCharacters.cs).
