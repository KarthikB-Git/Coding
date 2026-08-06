# 🌌 The Forge: A Repository of Algorithms & Problem Solving

> _"The only way to learn a new programming language is by writing programs in it." — Dennis Ritchie_

---

## 🚀 Mission Control

Welcome to my personal workspace for algorithmic puzzles, technical challenges, and interview preparation.

Currently, this repository features an **automated C# xUnit Testbench** (`LeetCodeSandbox`), allowing solutions to be developed, tested, and iterated upon using unit tests.

## 🏗️ The Blueprint

My approach to organizing this repository is driven by context, not just syntax:

- **🏆 Contests**: High-pressure solutions from timed competitions.
- **💼 Interview Rounds**: Real-world problems and architectural discussions from technical screens.
- **🧩 Platforms**: A curated collection of challenges from LeetCode, Codeforces, HackerRank, and more.
- **🧠 Brain Teasers**: Mathematical and logic-heavy puzzles that keep the mind sharp.

---

## 🏗️ Repository Anatomy

The workspace is organized into projects designed for problem solving and continuous test-driven iteration:

```text
Coding/
├── LeetCodeSandbox/           # C# (.NET 10.0) xUnit Testbench
│   ├── Common/                # Data structures & test helpers
│   │   ├── ListNode.cs        # Singly-linked list node signature
│   │   ├── TreeNode.cs        # Binary tree node signature
│   │   └── TestHelpers.cs     # BuildList, ToArray, BuildTree helpers
│   ├── Solutions/             # Modular LeetCode solutions & unit tests
│   │   ├── 0001_TwoSum.cs     # Problem solution
│   │   └── 0001_TwoSumTests.cs # xUnit unit test suite
│   ├── LeetCodeSandbox.csproj
│   └── LeetCodeSandbox.sln
└── README.md
```

---

## ⚡ Problem-Solving Workflow

Every problem in `LeetCodeSandbox/Solutions` is kept isolated in its own namespace:

1. **Solution File** (`Solutions/<XXXX>_<ProblemName>.cs`):
   - Namespace: `LeetCodeTestbench.Solutions.P<XXXX>_<ProblemName>`
   - Contains the `public class Solution` matching LeetCode's method signatures directly.

2. **Test File** (`Solutions/<XXXX>_<ProblemName>Tests.cs`):
   - Namespace: `LeetCodeTestbench.Tests.P<XXXX>_<ProblemName>`
   - Uses `[Theory]` and `[InlineData]` / `TestHelpers` to verify test cases automatically.

---

## 🛠️ Commands & Running Tests

From inside `LeetCodeSandbox/`:

- **Run all tests:**
  ```bash
  dotnet test
  ```
- **Auto-run tests on save:**
  ```bash
  dotnet watch test
  ```
- **Run tests for a single problem:**
  ```bash
  dotnet test --filter "FullyQualifiedName~P0001_TwoSum"
  ```

---

## 📈 Status Check

![Algorithms](https://img.shields.io/badge/Focus-Algorithms-blueviolet?style=for-the-badge)
![Data Structures](https://img.shields.io/badge/Focus-Data%20Structures-ff69b4?style=for-the-badge)
![Problem Solving](https://img.shields.io/badge/Skill-Problem%20Solving-green?style=for-the-badge)
![.NET 10](https://img.shields.io/badge/.NET-10.0-blue?style=for-the-badge&logo=dotnet)
![xUnit](https://img.shields.io/badge/Testing-xUnit-red?style=for-the-badge)
![Focus](https://img.shields.io/badge/Focus-Algorithms%20%26%20Data%20Structures-violet?style=for-the-badge)

---

_Created with ☕ and curiosity._
