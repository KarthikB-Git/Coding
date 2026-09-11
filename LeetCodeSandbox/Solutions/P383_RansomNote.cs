using LeetCodeTestbench.Common;

namespace LeetCodeTestbench.Solutions.P383_RansomNote;

// https://leetcode.com/problems/ransom-note/
// Difficulty: Easy
// Tags: Hash Table, String, Counting
[Problem(383, "Ransom Note", Difficulty.Easy, Topic.HashTable, Topic.String, Topic.Counting)]
public class Solution
{
    public bool CanConstruct(string ransomNote, string magazine)
    {
        var ransomChCnt = new int[26];
        var magChCnt = new int[26];
        foreach (var t in ransomNote) ransomChCnt[t - 'a']++;
        foreach (var i in magazine) magChCnt[i - 'a']++;
        return ransomChCnt.Zip(magChCnt, (x, y) => x <= y).All(x => x);
    }
}

