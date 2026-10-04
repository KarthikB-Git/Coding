# 645. Set Mismatch

[Problem](https://leetcode.com/problems/set-mismatch/) · Easy · Hash Table

## Approach

Insert values into a dictionary. The value encountered twice is the duplicate. Then scan the expected range `1..n`; the value absent from the dictionary is the missing number.

## Why it works

The array should contain each number from `1` to `n` exactly once. One duplicate necessarily replaces one missing value, so detecting the repeated insertion and the absent expected key yields the required pair.

## Complexity

- Time: `O(n)`.
- Space: `O(n)`.

See [the implementation](P645_SetMismatch.cs).
