# 1700. Number of Students Unable to Eat Lunch

[Problem](https://leetcode.com/problems/number-of-students-unable-to-eat-lunch/) · Easy · Queue, Simulation

## Approach

Put students in a queue and sandwiches in a stack whose top is the next sandwich. If the front student wants it, serve both and reset a rotation counter; otherwise rotate that student to the back. Stop after a full queue rotation without a match.

## Why it works

Any successful serving removes one student and changes the next sandwich, so trying again is meaningful. Conversely, a complete rotation with no match proves nobody wants the current sandwich, and no further progress is possible.

## Complexity

- Time: `O(n²)` in the worst-case simulation.
- Space: `O(n)`.

See [the implementation](P1700_NumberOfStudentsUnableToEatLunch.cs).
