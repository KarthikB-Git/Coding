# 3483. Unique 3-Digit Even Numbers

[Problem](https://leetcode.com/problems/unique-3-digit-even-numbers/) · Easy · Enumeration

## Approach

Enumerate all ordered triples of distinct digit indices. Reject a leading zero and an odd final digit, construct the resulting number, and insert it into a hash set to deduplicate equal values formed from repeated digits.

## Why it works

Every valid three-digit even number chooses three different input positions in a specific order, so the nested loops enumerate every candidate. The filters enforce validity and the set makes each numeric result count once.

## Complexity

- Time: `O(n³)`.
- Space: `O(u)`, where `u` is the number of unique valid numbers.

See [the implementation](P3483_Unique3DigitEvenNumbers.cs).
