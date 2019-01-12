// 153 https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/description/
// Similar to find element in rotated sorted 
// Except that, the pivot follows: prev > pivot and next > pivot
// And it can't lie in sorted half
// Edge case: what about sorted array or when the smallest occurs at right most?
public class Solution {
    public int FindMin(int[] nums) {
        if(nums == null || nums.Length == 0) return -1;
        int lo = 0, hi = nums.Length-1;
        
        while(lo < hi) {
            int mid = lo + (hi-lo)/2;
            
            // no rotation
            if(nums[lo] < nums[hi])
                return nums[lo];
            
            // won't lie in sorted half so we reduce search space to unsorted half
            else if(nums[lo] <= nums[mid]) {
                lo = mid+1;
            }
            else {
                hi = mid;
            }
        }
        
        return nums[lo];
    }
}
