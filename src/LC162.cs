// 162 M https://leetcode.com/problems/find-peak-element/description/
// In binary search, always think about how you will eliminate/divide search space
// Here, for a number x, if it is in a decreasing slope (x-1 < x < x+1) then the peak will definitely lie to the left
// Similary, if it is in an increasing slope, the peak will always lie to right
// This is how you reduce search space
// This works for unsorted arrays with duplicates too

public class Solution {
    public int FindPeakElement(int[] nums) {
        if(nums == null || nums.Length == 0) return -1;
        int lo = 0, hi = nums.Length-1;
        
        while(lo < hi) {
            int mid = lo + (hi-lo)/2;
            if(nums[mid] < nums[mid+1])
                lo = mid+1;
            else
                hi = mid;
        }
        
        return lo;
    }
}
