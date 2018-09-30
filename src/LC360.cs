// https://leetcode.com/problems/sort-transformed-array/description/
// Logic:
//          Quadratic equations are symmetric around line y = k where (h,k) is the maxima/minima depending on sign of a
//          i.e
//              - if a >= 0, x = -b/2a will give minimum point. (h = -b/2a, k = value at this h)
//              - if a < 0, x = -b/2a will give maximum point

//          So depending on sign of a, as we move farther away from 'h', values will symmetrically increase or decrease
//          i.e
//              - if a >= 0, as we move farther away from h on both sides, value will increase
//              - if a < 0, as we move farther away from h on both sides, value will decrease

// Instead of finding h and then moving away and checking values, we can just start two pointers at beginning and end and fill our result array. 
//  - If a >= 0, then we fill from end, because we know that as we move farther our values increase. 
//  - Similarly if a < 0, we fill from beginning coz we know that as we move farther, values will decrease.

// We simply use two pointers for this

// Time Complexity: O(n)
// Space Complexity: O(n)

public class Solution {
    public int[] SortTransformedArray(int[] nums, int a, int b, int c) {
        int l = nums.Length;
        int s = 0, e = l-1;
        
        int[] res = new int[l];
        int index = a >= 0 ? l-1 : 0;
        
        while(s <= e) {
            if(a >= 0) {
                res[index--] = Quad(a,b,c,nums[s]) > Quad(a,b,c,nums[e]) ? Quad(a,b,c,nums[s++]) : Quad(a,b,c,nums[e--]);
            }
            else {
                res[index++] = Quad(a,b,c,nums[s]) < Quad(a,b,c,nums[e]) ? Quad(a,b,c,nums[s++]) : Quad(a,b,c,nums[e--]);
            }
        }
        
        return res;
    }
    
    public int Quad(int a, int b, int c, int x) {
        return a*x*x + b*x + c;
    }
}