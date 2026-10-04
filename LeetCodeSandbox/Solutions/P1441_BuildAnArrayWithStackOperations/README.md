# 1441. Build an Array With Stack Operations

[Problem](https://leetcode.com/problems/build-an-array-with-stack-operations/) · Medium · Simulation

## Approach

Simulate the input stream from `1`. For each required target value, emit `Push` and `Pop` for every smaller skipped stream value, then emit `Push` for the target itself. Stop once the target is built.

## Why it works

Stream values are increasing and cannot be revisited. A non-target value must be removed immediately, while each target value must remain, so the emitted operations are exactly the required simulation.

## Complexity

- Time: `O(last target value)`.
- Space: `O(last target value)` for the returned operations.

See [the implementation](P1441_BuildAnArrayWithStackOperations.cs).
