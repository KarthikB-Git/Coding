# ⚡ LeetCode C# Testbench

A lightweight, high-performance xUnit test environment built on **.NET 10.0** for solving LeetCode problems locally with instant test feedback.

---

## 📁 Project Structure

- 🧩 **`Solutions/`**: Individual problem solution files and their corresponding xUnit test files.
- 🧰 **`Common/`**: Shared data structures (`ListNode`, `TreeNode`) and build helpers (`TestHelpers.cs`).
- **`Templates/`**: Boilerplate templates for solution and test files:
  - `SolutionBoilerplate.cs`
  - `SolutionTestsBoilerplate.cs`

---

## ➕ Adding a New Problem

Follow these simple steps when solving a new problem (e.g. `P2_AddTwoNumbers`):

1. **Pick problem ID and name**: `P2_AddTwoNumbers`
2. **Create Solution File** (`Solutions/P2_AddTwoNumbers.cs` or copy from `Templates/SolutionBoilerplate.cs`):

   ```csharp
   namespace LeetCodeTestbench.Solutions.P2_AddTwoNumbers;

   public class Solution {
       // Paste LeetCode boilerplate here
   }
   ```

3. **Create Test File** (`Solutions/P2_AddTwoNumbersTests.cs` or copy
   from `Templates/SolutionTestsBoilerPlate.cs`):

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

## 🧪 Test Commands

| Command                                                      | Action                              |
| :----------------------------------------------------------- | :---------------------------------- |
| `dotnet test`                                                | Run all problem tests               |
| `dotnet watch test`                                          | Run tests automatically on save     |
| `dotnet test --filter "FullyQualifiedName~P2_AddTwoNumbers"` | Run test suite for a single problem |

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
