// 34 M https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/description/
public class Solution {
    public int[] SearchRange(int[] nums, int target) {
        if(nums == null || nums.Length == 0)
            return new int[]{-1,-1};
        
        int[] res = new int[2];
        res[0] = First(nums,target);
        res[1] = Last(nums,target);
        return res;
    }
    
    // Reducing search space:
    // If nums[mid] is target, we need to know if this is the leftmost
    // 1. Either this is leftmost (i.e first element of array or prev element is not same as tgt)
    // 2. If not, it means there are more to left, so we adjust hi to mid-1 (mid-1 since we know for sure mid-1 == tgt)
    private int First(int[] nums, int t) {
        int lo = 0, hi = nums.Length-1;
        while(lo < hi) {
            int mid = lo + (hi-lo)/2;
            if(nums[mid] < t) 
                lo = mid+1;
            else if(nums[mid] > t)
                hi = mid-1;
            else if((mid == 0 && nums[mid] == t) || (nums[mid] == t && nums[mid-1] != t))
                return mid;
            else
                hi = mid-1;
        }
        return nums[lo] == t ? lo : -1;
    }
    
    private int Last(int[] nums, int t) {
        int lo = 0, hi = nums.Length-1;
        while(lo < hi) {
            int mid = lo + (hi-lo)/2;
            if(nums[mid] > t)
                hi = mid-1;
            else if(nums[mid] < t)
                lo = mid+1;
            else if((mid == nums.Length-1 && nums[mid] == t) || (nums[mid] == t && nums[mid+1] != t))
                return mid;
            else  
                lo = mid+1;
        }
        return nums[lo] == t ? lo : -1;
    }
}
