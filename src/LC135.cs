// 135  H https://leetcode.com/problems/candy/description/
// Space: O(n)
// Time: O(n)

// Lesson: Since we're talking about constraints on immediate neighbors: aka immediate left and right element:
//              (1) Our dependency is on what ever value immediate left/right hold, and nothing related to the range in left/right subarray
//              (2) We can scan from left, and scan from right to make sure we get dependencies correct in step (1)

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
        
        // make sure that we have at least one more candy than left neighbor
        for(int i = 1; i < ratings.Length; i++) {
            if(ratings[i] > ratings[i-1]) {
                l2r[i] = 1 + l2r[i-1];
            }
        }
        
        // make sure we have at least one more candy than right neighbor
        for(int i = ratings.Length-2; i >= 0; i--) {
            if(ratings[i] > ratings[i+1]) {
                r2l[i] = 1 + r2l[i+1];
            }
        }
        
        // make sure that the amount of candy is more than left and right neighbor
        int sum = 0;
        for(int i = 0; i < ratings.Length; i++) {
            sum += Math.Max(l2r[i], r2l[i]);
        }
        
        return sum;
    }
}

// Alternate: Reduce additional r2l array because you just need to keep track of one element, once l2r is filled
public class Solution {
    public int Candy(int[] ratings) {
        int[] l2r = new int[ratings.Length];
        
        // Init: each child gets one candy
        for(int i = 0; i < ratings.Length; i++) { l2r[i] = 1; }
        
        // make sure we have one more candy than left neighbors
        for(int i = 1; i < ratings.Length; i++) {
            if(ratings[i] > ratings[i-1]) {
                l2r[i] = 1 + l2r[i-1];
            }
        }
        
        // init sum as right most candy coz we will be scanning from penultimate element
        int sum = l2r[ratings.Length-1];

        for(int i = ratings.Length-2; i >= 0; i--) {
            // if current rating > right neighbor, ensure that we have 1 more candy than right neighbor and 1 more candy than left neighbor
            // since we ensured already that we have one more candy than left neighbor, we just do a max as follows
            if(ratings[i] > ratings[i+1]) {
                l2r[i] = Math.Max(l2r[i], 1 + l2r[i+1]);
            }
            sum += l2r[i];
        }
        
        return sum;
    }
}