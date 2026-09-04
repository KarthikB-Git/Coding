namespace LeetCodeTestbench.Solutions.P1475_FinalPricesWithASpecialDiscountInAShop;

// https://leetcode.com/problems/final-prices-with-a-special-discount-in-a-shop/
// Difficulty: Easy
// Tags: Array, Stack, Monotonic Stack
public class Solution
{
    public int[] FinalPrices(int[] prices)
    {
        var ans = new int[prices.Length];
        for (int i = 0; i < prices.Length; i++)
        {
            ans[i] = prices[i];
            for (int j = i + 1; j < prices.Length; j++)
            {
                if (prices[i] >= prices[j])
                {
                    ans[i] -= prices[j];
                    break;
                }
            }
        }
        return ans;
    }
}

