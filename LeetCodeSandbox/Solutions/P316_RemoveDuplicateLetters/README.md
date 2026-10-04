# 316. Remove Duplicate Letters

[Problem](https://leetcode.com/problems/remove-duplicate-letters/) · Medium · Greedy, Monotonic Stack

## Approach

Record each letter's last occurrence. Build the answer with a stack and a `seen` array. Ignore a letter already present; otherwise pop larger stack letters while they occur again later, then push the current letter.

## Why it works

The stack is the smallest possible prefix among choices that can still contain every required letter. Popping a larger letter improves lexicographic order, and the last-occurrence check guarantees it can be added back later. Thus no required character is lost.

## Complexity

- Time: `O(n)`; each character enters and leaves the stack at most once.
- Space: `O(1)` for the lowercase alphabet, excluding the result.

See [the implementation](P316_RemoveDuplicateLetters.cs).
