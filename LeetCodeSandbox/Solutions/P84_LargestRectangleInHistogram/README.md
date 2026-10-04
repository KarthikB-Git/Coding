# 84. Largest Rectangle in Histogram

[Problem](https://leetcode.com/problems/largest-rectangle-in-histogram/) · Hard · Monotonic Stack

## Approach

Keep an increasing stack of `(height, startIndex)` pairs. When a shorter bar arrives, pop every taller bar: its rectangle can end just before the current index, so compute its area. Carry the earliest popped start index forward before pushing the current height. Finally, flush the remaining bars using the array length as their right boundary.

## Why it works

A popped height has just found its first smaller bar on the right; its stored start is immediately after the first smaller bar on the left. Those are the widest possible bounds for a rectangle of that height, and every candidate height is evaluated once.

## Complexity

- Time: `O(n)`; each bar is pushed and popped at most once.
- Space: `O(n)` for the stack.

See [the implementation](P84_LargestRectangleInHistogram.cs).
