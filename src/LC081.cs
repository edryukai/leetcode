// 81 M https://leetcode.com/problems/search-in-rotated-sorted-array-ii/description/
// Rotated sorted array but with duplicates

public class Solution {
    public bool Search(int[] nums, int target) {
        // step0: edge case
        if(nums == null || nums.Length == 0) return false;
        
        // step1: set range
        int lo = 0, hi = nums.Length-1;
        
        // step2: while(lo < hi)
        while(lo < hi) {
            int mid = lo + (hi-lo)/2;
            if(nums[mid] == target) 
                return true;
            // typically, if no elements repeat, then nums[lo] <= nums[mid] would help us identify the sorted half
            // but if numbers repeat: ex {1,3,1,1,1}, then we can not rely on that condition alone to identify the sorted half
            // so we add the following check
            else if((nums[lo] == nums[mid]) && (nums[mid] == nums[hi])) {
                lo++;
                hi--;
            }
            else if(nums[lo] <= nums[mid]) {
                if(target >= nums[lo] && target < nums[mid])
                    hi = mid-1;
                else
                    lo = mid+1;
            }
            else {
                if(target > nums[mid] && target <= nums[hi])
                    lo = mid+1;
                else
                    hi = mid-1;
            }
        }
        return nums[lo] == target;
    }
}
