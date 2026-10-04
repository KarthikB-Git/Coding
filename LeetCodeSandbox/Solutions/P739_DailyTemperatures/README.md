# 739. Daily Temperatures

[Problem](https://leetcode.com/problems/daily-temperatures/) · Medium · Monotonic Stack

## Approach

Store indices whose next warmer day is unknown in a decreasing-temperature stack. When today's temperature is warmer than the top index's temperature, pop that index and record the distance to today. Push today's index afterward.

## Why it works

An index stays on the stack until its first warmer day. Since intervening days failed to pop it, the day that does pop it is the nearest warmer day to its right. Indices left over have no answer and retain zero.

## Complexity

- Time: `O(n)`.
- Space: `O(n)`.

See [the implementation](P739_DailyTemperatures.cs).
