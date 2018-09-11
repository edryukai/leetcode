// 135  H https://leetcode.com/problems/candy/description/
// Space: O(n)
// Time: O(n)

// Approach 2: https://leetcode.com/problems/candy/solution/
// Logic:
//          - Populate two arrays l2r and r2l while traversing from left to right and right to left
//          - Initially arrays are filled such that each child gets one candy
//          - l2r: If current element rating > previous element rating, then candy for current element = 1 + candy for prev element
//          - r2l: If current element rating > next element rating, then candy for current element = 1 + candy for prev element
//          - Finally: candies[i] = max(l2r[i], r2l[i])

public class Solution {
    public int Candy(int[] ratings) {
        int[] l2r = new int[ratings.Length];
        int[] r2l = new int[ratings.Length];
        
        // Init: each child gets one candy
        for(int i = 0; i < ratings.Length; i++) { l2r[i] = 1; r2l[i] = 1; }
        
        for(int i = 1; i < ratings.Length; i++) {
            if(ratings[i] > ratings[i-1]) {
                l2r[i] = 1 + l2r[i-1];
            }
        }
        
        for(int i = ratings.Length-2; i >= 0; i--) {
            if(ratings[i] > ratings[i+1]) {
                r2l[i] = 1 + r2l[i+1];
            }
        }
        
        int sum = 0;
        for(int i = 0; i < ratings.Length; i++) {
            sum += Math.Max(l2r[i], r2l[i]);
        }
        
        return sum;
    }
}