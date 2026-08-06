# LeetCode C# Testbench

## Project Structure

- `Common/`: Data structures (`ListNode`, `TreeNode`) and build helpers (`TestHelpers.cs`).
- `Templates/`: Boilerplate templates for solution and test files:
  - `SolutionBoilerplate.cs`
  - `SolutionTestsBoilerplate.cs`
- `Solutions/`: Individual problem solution files and their corresponding xUnit test files.

## Adding a new problem

1. Pick the next number and name, e.g. `0002_AddTwoNumbers`.
2. Create `Solutions/0002_AddTwoNumbers.cs` (or copy from `Templates/SolutionBoilerplate.cs`):
   ```csharp
   namespace LeetCodeTestbench.Solutions.P0002_AddTwoNumbers;

   public class Solution {
       // Paste LeetCode boilerplate here
   }
   ```
3. Create `Solutions/0002_AddTwoNumbersTests.cs` (or copy from `Templates/SolutionTestsBoilerplate.cs`):
   ```csharp
   namespace LeetCodeTestbench.Tests.P0002_AddTwoNumbers;

   using LeetCodeTestbench.Common;
   using LeetCodeTestbench.Solutions.P0002_AddTwoNumbers;
   using Xunit;

   public class SolutionTests {
       private readonly Solution _sut = new();

       [Theory]
       [InlineData(...)]
       public void TestMethod(...) { ... }
   }
   ```
4. Run test for specific problem:
   ```bash
   dotnet test --filter "FullyQualifiedName~P0002_AddTwoNumbers"
   ```

## Running everything

- `dotnet test` — run all problem tests
- `dotnet watch test` — run tests automatically on save

## Linked Lists & Binary Trees Helpers

Use `Common/TestHelpers.cs` for building `ListNode` or `TreeNode` test inputs:

```csharp
var head = TestHelpers.BuildList(1, 2, 4);
var tree = TestHelpers.BuildTree(3, 9, 20, null, null, 15, 7);
```
