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

---

## 🛠️ CLI & Test Commands

Run all commands from inside the `LeetCodeSandbox/` directory:

| Action | Command |
| :--- | :--- |
| 🧪 **Run all tests** | `dotnet test` |
| 🔄 **Auto-run tests on save** | `dotnet watch test` |
| 🎯 **Run specific problem test** | `dotnet test --filter "FullyQualifiedName~P1_TwoSum"` |

---

## 📝 Committing Rules

All commit messages follow a standardized syntax: `<type>(<problem>): <short description>`

```text
<type>(<problem>): <short description>
```

| Type | Description | Example |
| :--- | :--- | :--- |
| `solve` | New problem solved (solution + testbench added) | `solve(P1_TwoSum): add solution and testbench` |
| `fix` | Correcting a previously solved solution | `fix(P2_AddTwoNumbers): resolve null pointer on empty list` |
| `refactor` | Cleaning up solution without changing logic/tests | `refactor(P1_TwoSum): optimize hash map lookup` |
| `test` | Adding/adjusting test cases without changing solution | `test(P1_TwoSum): add edge cases for negative numbers` |
| `chore` | Project setup, README updates, common helpers, etc. | `chore(readme): update commit guidelines` |

---

<p align="center">
  <i>Created with ☕, curiosity, and test-driven precision.</i>
</p>
