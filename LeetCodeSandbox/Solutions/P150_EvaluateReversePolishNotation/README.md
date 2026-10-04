# 150. Evaluate Reverse Polish Notation

[Problem](https://leetcode.com/problems/evaluate-reverse-polish-notation/) · Medium · Stack

## Approach

Push operands on a stack. On an operator, pop the right operand first and the left operand second, apply the operator, and push the result. The final stack value is the expression result.

## Why it works

In postfix notation, an operator appears after both complete operand expressions. The stack therefore contains precisely the available values, with the most recent two being the operator's operands. Preserving pop order matters for subtraction and division.

## Complexity

- Time: `O(n)`.
- Space: `O(n)` in the worst case.

See [the implementation](P150_EvaluateReversePolishNotation.cs).
