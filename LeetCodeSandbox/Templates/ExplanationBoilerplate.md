# LeetCode [Problem ID] - [Problem Title]

**Difficulty:** Unknown  **Topics:** None

> **LeetCode:** [https://leetcode.com/problems/problem-slug/](https://leetcode.com/problems/problem-slug/)

This guide explains the solution in small steps. Start with the key idea, then build toward the implementation.

---

## Step 0 - The problem in plain words

Explain what the input represents, what must be returned, and the rules that govern valid solutions.

| Input / Symbol | Meaning |
|---|---|
| `...` | Describe an important input value, grid symbol, or concept. |
| `...` | Describe another important input value, grid symbol, or concept. |

**Constraints that matter:** Identify the limits that determine the algorithm choice.

### Examples

```text
input -> output
```

---

## Step 1 - Spot the shape of the problem

Ask what cues reveal the right technique:

1. What is being optimized or decided?
2. Which constraints rule out a brute-force approach?
3. Is there a familiar pattern, such as BFS, dynamic programming, a monotonic stack, binary search, or a bitmask?

State the chosen algorithm and the reason it fits.

---

## Step 2 - Why the obvious approach fails

Describe the tempting first approach, why it is incorrect or too slow, and the observation that fixes it.

> **Key observation:** Write the one fact the reader should remember.

---

## Step 3 - Model the state / invariant

Define the information that completely determines what can happen next.

```text
state = (...)
```

- `...`: Explain each field, invariant, or data structure.
- `...`: Explain why it must be retained.

For a state-space search, explicitly state the start state, goal condition, and what counts as visited. For another algorithm, state the invariant maintained at every iteration.

---

## Step 4 - Transitions and algorithm

Explain the algorithm one action at a time:

1. Initialize the required structures.
2. Describe one transition / iteration / recurrence.
3. Explain pruning, ordering, or update rules.
4. Cover the base cases and termination condition.

Use a small pseudocode fragment when it makes the flow clearer.

```text
while work remains:
    choose the next item or state
    apply the transition
    update the answer / record the result
```

---

## Step 5 - Walk through an example

Trace one representative example. Show enough intermediate states that the key transition, invariant, or choice becomes concrete.

| Step | State / Input | Decision | Result |
|---|---|---|---|
| 0 | `...` | Initialize | `...` |
| 1 | `...` | Apply the key rule | `...` |

---

## Step 6 - The C# solution

```csharp
// Add the completed solution here, or link readers to the sibling .cs file.
```

### Why each piece is there

| Piece | Reason |
|---|---|
| `...` | Explain the purpose of this part of the implementation. |
| `...` | Explain an important correctness or performance detail. |

---

## Step 7 - Complexity

- **Time:** `O(...)` - explain which work dominates.
- **Space:** `O(...)` - identify the auxiliary structures included.

---

## Step 8 - Common mistakes to avoid

1. Describe a likely edge case or off-by-one error.
2. Describe a tempting but invalid optimization or state reduction.
3. Describe a language-specific or implementation detail to double-check.

---

## Step 9 - The pattern to remember

Summarize the reusable reasoning recipe in a compact form:

```text
problem cue -> algorithmic technique -> essential invariant or state
```

Optionally list a few related problems or variations that use the same idea.

---

## Step 10 - Test cases for the testbench

```csharp
[Theory]
[InlineData(/* representative input */, /* expected output */)]
public void MethodName_ReturnsExpected(/* parameters */)
{
    var solution = new Solution();
    Assert.Equal(/* expected */, solution.MethodName(/* arguments */));
}
```

Include normal cases, boundary cases, and a case that specifically exercises the key insight.
