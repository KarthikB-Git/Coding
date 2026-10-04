# 1480. Running Sum of 1d Array

[Problem](https://leetcode.com/problems/running-sum-of-1d-array/) · Easy · Prefix Sum

## Approach

Maintain a cumulative sum while walking left to right and overwrite each input position with that sum.

## Why it works

Before processing an index, the accumulator equals the sum of all prior values. Adding the current original value makes it exactly the prefix sum ending at that index, which is then stored in place.

## Complexity

- Time: `O(n)`.
- Space: `O(1)` auxiliary space; the input is modified.

See [the implementation](P1480_RunningSumOf1dArray.cs).
