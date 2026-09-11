namespace LeetCodeTestbench.Common;

public enum Difficulty
{
    Easy,
    Medium,
    Hard
}

public enum Topic
{
    Array,
    String,
    HashTable,
    DynamicProgramming,
    Math,
    Sorting,
    Greedy,
    DepthFirstSearch,
    BreadthFirstSearch,
    BinarySearch,
    Matrix,
    TwoPointers,
    BitManipulation,
    Stack,
    Heap,
    Graph,
    PrefixSum,
    Simulation,
    Design,
    Counting,
    Backtracking,
    SlidingWindow,
    UnionFind,
    LinkedList,
    Tree,
    BinaryTree,
    MonotonicStack,
    Trie,
    DivideAndConquer,
    Queue,
    Recursion,
    Memoization,
    SegmentTree,
    BinaryIndexedTree,
    ShortestPath,
    GameTheory,
    OrderedSet,
    RollingHash,
    Other
}

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public sealed class ProblemAttribute : Attribute
{
    public int Id { get; }
    public string Title { get; }
    public Difficulty Difficulty { get; }
    public Topic[] Topics { get; }

    public ProblemAttribute(int id, string title, Difficulty difficulty, params Topic[]? topics)
    {
        Id = id;
        Title = title;
        Difficulty = difficulty;
        Topics = topics ?? [];
    }
}
