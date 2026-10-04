# 1365. How Many Numbers Are Smaller Than the Current Number

[Problem](https://leetcode.com/problems/how-many-numbers-are-smaller-than-the-current-number/) · Easy · Array

## Approach

For every element, count the elements in the full array that are strictly smaller, then store that count in the corresponding output position.

## Why it works

The desired value for an element is precisely the cardinality of the set of array entries below it. Independently checking every entry computes that definition directly, including duplicates.

## Complexity

- Time: `O(n²)`.
- Space: `O(n)` for the output.

See [the implementation](P1365_HowManyNumbersAreSmallerThanTheCurrentNumber.cs).
