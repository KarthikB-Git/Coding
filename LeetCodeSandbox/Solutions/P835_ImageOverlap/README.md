# 835. Image Overlap

[Problem](https://leetcode.com/problems/image-overlap/) · Medium · Matrix, Translation Vectors

## Approach

Collect the coordinates of `1`s in both images. For every pair of one-cells, count the translation vector that would align the first with the second. The largest vector count is the maximum overlap.

## Why it works

Two one-cells overlap exactly when the same row and column shift maps one to the other. Counting equal shifts groups all one-cell pairs that align under a single translation, so the largest group is the answer.

## Complexity

- Time: `O(a × b)`, where `a` and `b` are the numbers of ones.
- Space: `O(a × b)` in the worst case for shift counts.

See [the implementation](P835_ImageOverlap.cs).
