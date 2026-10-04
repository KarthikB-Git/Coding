# 383. Ransom Note

[Problem](https://leetcode.com/problems/ransom-note/) · Easy · Counting

## Approach

Count the frequency of each lowercase letter in both strings, then verify that the magazine count is at least the ransom-note count for every letter.

## Why it works

Each ransom-note character consumes one independent magazine character. Frequency comparison exactly states whether every required character has enough available copies.

## Complexity

- Time: `O(r + m)`.
- Space: `O(1)` because the alphabet has 26 letters.

See [the implementation](P383_RansomNote.cs).
