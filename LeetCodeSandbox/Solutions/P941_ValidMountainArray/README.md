# 941. Valid Mountain Array

[Problem](https://leetcode.com/problems/valid-mountain-array/) · Easy · Array

## Approach

Walk upward while adjacent values strictly increase. The peak must be neither the first nor last index. From that peak, walk downward while values strictly decrease and accept only if the final index is reached.

## Why it works

A mountain has exactly two strict phases: ascent then descent. The two scans validate those phases and the peak check excludes arrays missing either one; equal neighbors fail both strict comparisons.

## Complexity

- Time: `O(n)`.
- Space: `O(1)`.

See [the implementation](P941_ValidMountainArray.cs).
