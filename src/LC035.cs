// 35 E https://leetcode.com/problems/search-insert-position/description/
// Search inserted position
public class Solution {
    public int SearchInsert(int[] nums, int target) {
        int lo = 0, hi = nums.Length-1;
        while(lo < hi) {
            int mid = lo + (hi-lo)/2;
            if(nums[mid] == target) return mid;
            else if(nums[mid] < target) lo = mid+1;
            else hi = mid;
        }
        
        if(nums[lo] == target) return lo;
        
        // Till above step it was standard binary search
        // Now if we haven't met target yet, we need to return where it would be inserted
        // If target > nums[lo], it will be inserted in immediate right, so we return lo+1
        // Else it would be inserted to left of lo, which means it will replace lo's position, so we return lo
        if(nums[lo] < target) {
            return lo+1;
        }
        else {
            return lo;
        }
    }
}
