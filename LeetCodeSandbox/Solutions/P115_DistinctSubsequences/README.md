# 115. Distinct Subsequences

[Problem](https://leetcode.com/problems/distinct-subsequences/) · Hard · Dynamic Programming

## Approach

Let `dp[i, j]` be the number of ways the first `i` characters of `s` form the first `j` characters of `t`. Skipping `s[i - 1]` always contributes `dp[i - 1, j]`; if the two current characters match, using it additionally contributes `dp[i - 1, j - 1]`.

## Why it works

Every valid subsequence either omits the current source character or, when it matches, uses it for the target's final character. These choices are disjoint and exhaustive. The empty target has one construction, which supplies the base case.

## Complexity

- Time: `O(|s| × |t|)`.
- Space: `O(|s| × |t|)`.

See [the implementation](P115_DistinctSubsequences.cs).
