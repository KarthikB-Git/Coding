using System.Diagnostics.CodeAnalysis;

#pragma warning disable IDE0051

namespace LeetCodeTestbench.Common;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
public enum Difficulty
{
    Easy,
    Medium,
    Hard
}

[SuppressMessage("ReSharper", "UnusedMember.Global")]
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
    Enumeration,
    Memoization,
    SegmentTree,
    BinaryIndexedTree,
    ShortestPath,
    GameTheory,
    OrderedSet,
    RollingHash,
    Bitmask,
    Concurrency,
    NumberTheory,
    Geometry,
    TopologicalSort,
    Quickselect,
    SuffixArray,
    DataStream,
    Interactive,
    StringMatching,
    MonotonicQueue,
    Combinatorics,
    ProbabilityAndStatistics,
    BucketSort,
    CountingSort,
    RadixSort,
    MergeSort,
    MinimumSpanningTree,
    LineSweep,
    ReservoirSampling,
    RejectionSampling,
    StronglyConnectedComponent,
    EulerianCircuit,
    BiconnectedComponent,
    Brainteaser,
    DoublyLinkedList,
    HashFunction,
    BinarySearchTree,
    Randomized,
    Shell,
    Other
}
[SuppressMessage("ReSharper", "RedundantAttributeUsageProperty")]
[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public sealed class ProblemAttribute : Attribute
{
    public int Id { get; }
    public string Title { get; }
    public Difficulty Difficulty { get; }
    public Topic[] Topics { get; }
    [SuppressMessage("ReSharper", "ConvertToPrimaryConstructor")]
    public ProblemAttribute(int id, string title, Difficulty difficulty, params Topic[]? topics)
    {
        Id = id;
        Title = title;
        Difficulty = difficulty;
        Topics = topics ?? [];
    }
}
