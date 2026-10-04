# 66. Plus One

[Problem](https://leetcode.com/problems/plus-one/) · Easy · Array, Math

## Approach

Treat the digits as manual addition. Scan from right to left: increment the first digit below `9` and return. A `9` becomes `0` and carries into the next position. If every digit was `9`, allocate one extra digit with a leading `1`.

## Why it works

The carry from adding one can only travel through a suffix of `9`s. Every earlier digit is unchanged, so resolving that suffix produces exactly the decimal representation of the incremented number.

## Complexity

- Time: `O(n)` in the all-`9`s case.
- Space: `O(1)` auxiliary space; the all-`9`s result needs `O(n)` output space.

See [the implementation](P66_PlusOne.cs).
