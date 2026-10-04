# 448. Find All Numbers Disappeared in an Array

[Problem](https://leetcode.com/problems/find-all-numbers-disappeared-in-an-array/) · Easy · Array

## Approach

Use the input as a presence map. For each value `v`, negate the element at index `abs(v) - 1` if it is still positive. A positive value left at index `i` means number `i + 1` never appeared.

## Why it works

Every valid value maps to one unique index. Seeing a value marks that index regardless of duplicates, so an unmarked index corresponds exactly to a missing number.

## Complexity

- Time: `O(n)`.
- Space: `O(1)` auxiliary space; the input array is modified.

See [the implementation](P448_FindAllNumbersDisappearedInAnArray.cs).
