
# 14. Longest Common Prefix

[Problem](https://leetcode.com/problems/longest-common-prefix/) · Easy · Array, String, Trie

## Approach

Find the length of the shortest string first, since a common prefix cannot extend beyond it. Then examine every index up to that length. At each index, use the character from the first string as the reference and compare it with the character at the same index in every other string.

If every character matches, append that character to the prefix. Stop at the first mismatch and return the prefix accumulated so far.

## Why it works

A character belongs to the common prefix exactly when every string has that same character at that position. The algorithm checks this condition from left to right, so it accepts every valid prefix character in order. Once a position differs, no longer prefix can be common, making the accumulated result the longest common prefix.

## Complexity

- Time: `O(n × L)`, where `n` is the number of strings and `L` is the shortest string length.
- Space: `O(L)` for the returned prefix.

See [the implementation](P14_LongestCommonPrefix.cs).
