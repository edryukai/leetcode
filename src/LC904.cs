// https://leetcode.com/problems/fruit-into-baskets/description/
// Fruit into baskets (moving window)

// Algo:
// Moving Window
// Logic is very similar to finding a subarray of maximum size that has two distinct values
// Time Complexity: O(n)
// Space Complexity: O(n)

public class Solution {
    public int TotalFruit(int[] tree) {
        if(tree.Length <= 2) { return tree.Length; }
        
        int i = 0, max = 0, numDistinct = 0;
        var count = new Dictionary<int,int>();
        
        // Initialize dictionary with 0 counts
        for(int v = 0; v < tree.Length; v++) 
            count[tree[v]] = 0;
        
        // Increasing 'end' of the window
        for(int j = 0; j < tree.Length; j++) {
            if(count[tree[j]] == 0)
                numDistinct++;
            count[tree[j]]++;
            
            // while we are violating the window condition, increase 'start' of the window till we don't violate the window condition
            while(numDistinct > 2) {
                count[tree[i]]--;
                if(count[tree[i]] == 0)
                    numDistinct--;
                
                i++;
            }

            // Record length after every valid window
            max = Math.Max(max, j-i+1);
        }
        return max;
    }
}