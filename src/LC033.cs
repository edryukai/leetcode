// 33 M https://leetcode.com/problems/search-in-rotated-sorted-array/description/
// No duplicates in array
// Logic:
//          - if target is mid, return
//          - else one of the two subarrays divided by mid is sorted (the other has the rotation pivot)
//          - you can definitely rule in / rule out the sorted subarray, thus we reduce our space in half and maintain O(log n)
public class Solution {
    public int Search(int[] nums, int target) {
        // step 0: base case
        if(nums == null || nums.Length == 0) return -1;
        // step 1: set bounds
        int lo = 0, hi = nums.Length-1;
        // step 2: while(lo < hi)
        while(lo < hi) {
            int mid = lo + (hi-lo)/2;
            if(nums[mid] == target)
                return mid;
            
            // left part is sorted
            if(nums[lo] <= nums[mid]) {
                if(target >= nums[lo] && target < nums[mid])    // target lies in this sorted half
                    hi = mid-1;
                else
                    lo = mid+1;
            }
            // right part is sorted
            else {
                if(target > nums[mid] && target <= nums[hi])
                    lo = mid+1;
                else
                    hi = mid-1;
            }
        }
        return nums[lo] == target ? lo : -1;
    }
}
