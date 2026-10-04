# 1672. Richest Customer Wealth

[Problem](https://leetcode.com/problems/richest-customer-wealth/) · Easy · Matrix

## Approach

Sum each customer's account row and return the largest row sum.

## Why it works

A customer's wealth is defined as the total across that customer's accounts. Computing each row total and taking their maximum directly matches the definition.

## Complexity

- Time: `O(rows × columns)`.
- Space: `O(1)` auxiliary space.

See [the implementation](P1672_RichestCustomerWealth.cs).
