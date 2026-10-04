# 412. Fizz Buzz

[Problem](https://leetcode.com/problems/fizz-buzz/) · Easy · Simulation

## Approach

For each integer from `1` through `n`, append `Fizz` when divisible by `3` and `Buzz` when divisible by `5`. If neither condition applies, append the number itself.

## Why it works

The required output is defined independently for each integer. Checking both divisibility rules before falling back to the number also correctly handles multiples of both as `FizzBuzz`.

## Complexity

- Time: `O(n)`.
- Space: `O(n)` for the returned list.

See [the implementation](P412_FizzBuzz.cs).
