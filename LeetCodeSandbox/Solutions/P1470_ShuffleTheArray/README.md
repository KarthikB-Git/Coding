# 1470. Shuffle the Array

[Problem](https://leetcode.com/problems/shuffle-the-array/) · Easy · Array

## Approach

The input is `[x1, …, xn, y1, …, yn]`. For every offset `i`, write `xi` to output index `2i` and `yi` to output index `2i + 1`.

## Why it works

Each iteration places one required adjacent pair in its final positions. The offsets cover every item in both halves exactly once, producing the required interleaving.

## Complexity

- Time: `O(n)`.
- Space: `O(n)` for the output.

See [the implementation](P1470_ShuffleTheArray.cs).
