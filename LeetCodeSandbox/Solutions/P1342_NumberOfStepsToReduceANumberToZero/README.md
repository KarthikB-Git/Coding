# 1342. Number of Steps to Reduce a Number to Zero

[Problem](https://leetcode.com/problems/number-of-steps-to-reduce-a-number-to-zero/) · Easy · Bit Manipulation

## Approach

While the number is positive, inspect its least significant bit. An even number is halved with a right shift; an odd number is decremented. Count each operation.

## Why it works

Parity completely determines the only permitted operation. The loop applies that rule until zero, so its counter is exactly the number of required reductions.

## Complexity

- Time: `O(log num)`.
- Space: `O(1)`.

See [the implementation](P1342_NumberOfStepsToReduceANumberToZero.cs).
