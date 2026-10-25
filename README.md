# 🌌 The Forge: Algorithms & Problem Solving

![Focus](https://img.shields.io/badge/Focus-Algorithms%20%26%20Data%20Structures-violet?style=for-the-badge)
![.NET 10](https://img.shields.io/badge/.NET-10.0-blue?style=for-the-badge&logo=dotnet)
![xUnit](https://img.shields.io/badge/Testing-xUnit-red?style=for-the-badge)
![Problem Solving](https://img.shields.io/badge/Skill-Problem%20Solving-green?style=for-the-badge)

> _"The only way to learn a new programming language is by writing programs in it."_ — Dennis Ritchie

---

## 🚀 Mission Control

Welcome to **The Forge** — a personal workspace for algorithmic puzzles, technical challenges, and interview preparation.

The core of this repository features an **automated C# xUnit Testbench** (`LeetCodeSandbox`), allowing solutions to be developed, tested, and iterated upon using unit tests and test-driven development (TDD).

---

## 🎯 Repository Vision

My approach to organizing this repository is driven by context:

- 🏆 **Contests**: High-pressure solutions from timed competitions.
- 💼 **Interview Prep**: Classic algorithms, real-world problems, and architectural discussions.
- 🧩 **Platforms**: Curated challenges from LeetCode, Codeforces, HackerRank, and more.
- 🧠 **Brain Teasers**: Mathematical, puzzle, and logic-heavy challenges.

---

## 🏗️ Repository Anatomy

```text
Coding/
├── LeetCodeSandbox/              # C# (.NET 10.0) xUnit Testbench
│   ├── Common/                   # Data structures & test helpers
│   │   ├── ListNode.cs           # Singly-linked list node signature
│   │   ├── TreeNode.cs           # Binary tree node signature
│   │   └── TestHelpers.cs        # BuildList, ToArray, BuildTree helpers
│   ├── Solutions/                # Modular LeetCode solutions & unit tests
│   │   ├── P1_TwoSum.cs          # Problem solution
│   │   └── P1_TwoSumTests.cs     # xUnit test suite
│   ├── Templates/                # Boilerplate templates for solution & test files
│   │   ├── SolutionBoilerplate.cs
│   │   └── SolutionTestsBoilerplate.cs
│   ├── LeetCodeSandbox.csproj
│   └── LeetCodeSandbox.slnx
└── README.md
```

---

## ⚡ Problem-Solving Workflow

Every problem in `LeetCodeSandbox/Solutions` is kept isolated in its own namespace using standard naming rules:

### 📌 Naming Conventions
- **Pattern**: `P<ProblemNumber>_<ProblemName>`
- **`<ProblemNumber>`**: Numeric LeetCode problem ID (e.g. `1`, `2`, `141`).
- **`<ProblemName>`**: Title in **PascalCase** (e.g. `TwoSum`, `AddTwoNumbers`).

| Component | File Path Format | Namespace Structure |
| :--- | :--- | :--- |
| **Solution** | `Solutions/P<ID>_<Name>.cs` | `LeetCodeTestbench.Solutions.P<ID>_<Name>` |
| **Test Suite** | `Solutions/P<ID>_<Name>Tests.cs` | `LeetCodeTestbench.Tests.P<ID>_<Name>` |

### ➕ Adding a New Problem

Follow these simple steps when solving a new problem (e.g. `P2_AddTwoNumbers`):

1. **Pick problem ID and name**: `P2_AddTwoNumbers`
2. **Create Solution File** (`Solutions/P2_AddTwoNumbers.cs` or copy from `Templates/SolutionBoilerplate.cs`):

   ```csharp
   namespace LeetCodeTestbench.Solutions.P2_AddTwoNumbers;

   public class Solution {
       // Paste LeetCode boilerplate here
   }
   ```

3. **Create Test File** (`Solutions/P2_AddTwoNumbersTests.cs` or copy from `Templates/SolutionTestsBoilerplate.cs`):

   ```csharp
   namespace LeetCodeTestbench.Tests.P2_AddTwoNumbers;

   using LeetCodeTestbench.Solutions.P2_AddTwoNumbers;
   using Xunit;

   public class SolutionTests {
       private readonly Solution _sut = new();

       [Theory]
       [InlineData(...)]
       public void TestMethod(...) { ... }
   }
   ```

4. **Run Test for Specific Problem**:
   ```bash
   dotnet test --filter "FullyQualifiedName~P2_AddTwoNumbers"
   ```

---

## Problem-specific test benches with an AI agent

Scaffold a problem from its URL, then generate tests that follow its actual judge contract:

```powershell
./scripts/New-SolutionFromUrl.ps1 -Url https://leetcode.com/problems/remove-duplicates-from-sorted-array/
./scripts/New-ProblemTestBench.ps1 -ProblemName P26_RemoveDuplicatesFromSortedArray -RunAgent -ReplaceExistingTests
```

The URL script saves the complete description to `ProblemStatement.html` beside the solution. Custom-judge and void-method problems receive an explicitly skipped placeholder instead of return-only assertions. The second command invokes your installed, signed-in Codex CLI, using its configured model and a workspace-write sandbox, to analyze the statement and C# signatures and write the problem's `*Test.cs` plus `TestBench.md`. The VS Code task **Generate Problem Test Bench (AI)** runs the same generation step and authorizes updating that problem's existing test file.

The agent is instructed to validate return values and required input mutations, ignore unspecified state, cover valid edge cases, use an independent oracle for seeded random tests where practical, and check the validator against incorrect outcomes. It must run the filtered xUnit suite and record its results. An unsolved solution can legitimately fail these tests; the agent must leave the implementation alone. Review the generated contract and assertions, since generated tests still require judgment and cannot guarantee passing LeetCode's hidden tests.

For an existing or manually scaffolded problem, supply the full statement yourself:

```powershell
./scripts/New-ProblemTestBench.ps1 -ProblemName P66_PlusOne -StatementPath ./problem.md -RunAgent -ReplaceExistingTests
```

Omit `-RunAgent` to emit the complete task as plain text for inspection or use with another coding agent. This mode requires no CLI or network access and changes no files. `-ReplaceExistingTests` explicitly permits updates to the named test file; without it, execution refuses to overwrite that file. Keep the complete statement, including constraints and custom-judge code, in the supplied text, Markdown, or HTML file. The generated `TestBench.md` records judge semantics, oracle design, coverage, and verification limitations. The script checks that both output files exist; the agent's report and test results still need review.

To check the tooling without an AI call or LeetCode access:

```powershell
./scripts/tests/Test-ProblemTestBench.ps1
```

---

## 💡 Linked Lists & Binary Trees Helpers

Use `Common/TestHelpers.cs` to construct `ListNode` or `TreeNode` test inputs cleanly:

```csharp
// Build a singly linked list (1 -> 2 -> 4)
var head = TestHelpers.BuildList(1, 2, 4);

// Build a binary tree from array representation
var tree = TestHelpers.BuildTree(3, 9, 20, null, null, 15, 7);
```

---

## 🛠️ CLI & Test Commands

Run all commands from inside the `LeetCodeSandbox/` directory:

| Action | Command |
| :--- | :--- |
| 🧪 **Run all tests** | `dotnet test` |
| 🔄 **Auto-run tests on save** | `dotnet watch test` |
| 🎯 **Run specific problem test** | `dotnet test --filter "FullyQualifiedName~P1_TwoSum"` |

---

# 📝 Committing Rules

All commit messages follow a standardized syntax:

```text
<type>(<problem>): <short description>
```

`<problem>` should match the solution filename scope, e.g. `P1_TwoSum`, `P42_TrappingRainWater`.

| Type | Description | Example |
| :--- | :--- | :--- |
| `solve` | New problem solved (solution + testbench added) | `solve(P1_TwoSum): add solution and testbench` |
| `fix` | Correcting a previously solved solution | `fix(P2_AddTwoNumbers): resolve null pointer on empty list` |
| `refactor` | Cleaning up solution without changing logic/tests | `refactor(P1_TwoSum): optimize hash map lookup` |
| `perf` | Optimizing time/space complexity of a working solution | `perf(P42_TrappingRainWater): reduce to O(1) space using two pointers` |
| `test` | Adding/adjusting test cases without changing solution | `test(P1_TwoSum): add edge cases for negative numbers` |
| `docs` | Adding explanations, complexity notes, or comments to a solution | `docs(P200_NumIslands): add BFS vs DFS complexity notes` |
| `wip` | Incomplete/in-progress solution, committed as a checkpoint | `wip(P4_MedianOfTwoSortedArrays): partial binary search approach` |
| `revert` | Reverting a previous commit | `revert(P15_3Sum): revert perf change causing TLE` |
| `style` | Formatting, naming, whitespace — no logic change | `style(P1_TwoSum): rename variables for clarity` |
| `deps` | Adding/updating NuGet packages or project dependencies | `deps: add xUnit and FluentAssertions packages` |
| `ci` | Changes to build/test automation, VS Code tasks, scripts | `ci: add URL-based solution scaffold task` |
| `topic` | Tagging a solution under a pattern/category | `topic(P1_TwoSum): tag as hash-map pattern` |
| `chore` | Project setup, README updates, common helpers, etc. | `chore(readme): update commit guidelines` |

---

<p align="center">
  <i>Created with ☕, curiosity, and test-driven precision.</i>
</p>
