# 1929. Concatenation of Array

[Problem](https://leetcode.com/problems/concatenation-of-array/) · Easy · Array

## Approach

Allocate an array twice as long. Copy each input value to both its original index and the same index offset by the input length.

## Why it works

The first block is one copy of the input and the second block is another copy. Together they are exactly `nums + nums` in order.

## Complexity

- Time: `O(n)`.
- Space: `O(n)` for the output.

See [the implementation](P1929_ConcatenationOfArray.cs).
