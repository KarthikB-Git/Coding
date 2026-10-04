# 636. Exclusive Time of Functions

[Problem](https://leetcode.com/problems/exclusive-time-of-functions/) · Medium · Stack

## Approach

Maintain a stack of active function IDs and the timestamp of the previous event boundary. Before processing each log, charge the elapsed interval to the active function. End logs are shifted by one because their timestamp is inclusive; then push or pop the logged function and update the boundary.

## Why it works

The top stack entry is the only function executing between consecutive event boundaries. Charging each such interval once partitions all execution time correctly, while the inclusive-end adjustment includes the final unit of an ending call.

## Complexity

- Time: `O(logs.Count)`.
- Space: `O(n)` for nested calls.

See [the implementation](P636_ExclusiveTimeOfFunctions.cs).
