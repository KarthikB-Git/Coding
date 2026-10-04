# 3903. Smallest Stable Index I

[Problem](https://leetcode.com/problems/smallest-stable-index-i/) · Easy · Array, Prefix/Suffix Aggregates

## Approach

Precompute `suffixMin[i]`, the smallest value from index `i` to the end. Then sweep left to right while maintaining the maximum value seen in the prefix. The first index where `prefixMax - suffixMin[i] <= k` is returned.

## Why it works

At each candidate index, the two maintained aggregates summarize the extreme values relevant to the split: the largest value on the left and the smallest value from the candidate onward. Their difference is therefore the required stability measure, and left-to-right order guarantees the first valid index is smallest.

## Complexity

- Time: `O(n)`.
- Space: `O(n)` for the suffix-minimum array.

See [the implementation](P3903_SmallestStableIndexI.cs).
