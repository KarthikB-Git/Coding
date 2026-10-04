# 485. Max Consecutive Ones

[Problem](https://leetcode.com/problems/max-consecutive-ones/) · Easy · Array

## Approach

Scan once with a running count of the current streak. Increment it for `1`, reset it for `0`, and retain the largest count observed.

## Why it works

At each position the running count is exactly the length of the suffix of consecutive ones ending there. Taking the maximum across all positions therefore finds the longest streak.

## Complexity

- Time: `O(n)`.
- Space: `O(1)`.

See [the implementation](P485_MaxConsecutiveOnes.cs).
