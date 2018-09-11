// https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/description/
// Space complexity: O(1)
// Time complexity: O(log n)

public class Solution {
    public int[] SearchRange(int[] nums, int target) {
        int[] res = new int[] {-1,-1};
        
        if(nums == null || nums.Length == 0)
            return res;
        
        res[0] = FirstOccurance(nums, target);
        res[1] = LastOccurance(nums, target);
        
        return res;
    }
    
    public int FirstOccurance(int[] nums, int target) {
        int lo = 0, hi = nums.Length-1;
        
        while(lo < hi) {
            int mid = lo + (hi-lo)/2;
            
            if((mid == 0 && nums[mid] == target) || (mid-1 >= 0 && nums[mid] == target && nums[mid-1] != target))
                return mid;
            else if(nums[mid] < target)
                lo = mid+1;
            else if(nums[mid] > target)
                hi = mid-1;
            else    // nums[mid] == target && nums[mid-1] == target as well
                hi = mid-1;
        }
        
        return nums[lo] == target ? lo : -1;
    }
    
    public int LastOccurance(int[] nums, int target) {
        int lo = 0, hi = nums.Length-1;
        
        while(lo < hi) {
            int mid = lo + (hi-lo)/2;
            
            if((nums[mid] == target && mid == nums.Length-1) || (nums[mid] == target && nums[mid+1] != target))
                return mid;
            else if(nums[mid] < target)
                lo = mid+1;
            else if(nums[mid] > target)
                hi = mid-1;
            else    // nums[mid] == target && nums[mid+1] == target as well
                lo = mid+1;
        }
        
        return nums[lo] == target ? lo : -1;
    }
}