# 1475. Final Prices With a Special Discount in a Shop

[Problem](https://leetcode.com/problems/final-prices-with-a-special-discount-in-a-shop/) · Easy · Array

## Approach

For each price, scan right until finding the first price no greater than it. Subtract that first qualifying price; if none exists, leave the price unchanged.

## Why it works

The problem defines the discount as the first later qualifying price, not the smallest one. The inner scan visits later items in order and stops exactly at that first valid discount.

## Complexity

- Time: `O(n²)` in the worst case.
- Space: `O(n)` for the output.

See [the implementation](P1475_FinalPricesWithASpecialDiscountInAShop.cs).
