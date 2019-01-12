// 154 H https://leetcode.com/problems/find-minimum-in-rotated-sorted-array-ii/description/
// Same as min in rotated sorted array but with duplicates
// so we add the duplicates condition as an additional check
public class Solution {
    public int FindMin(int[] nums) {
        if(nums == null || nums.Length == 0) return -1;
        int lo = 0, hi = nums.Length-1;
        
        while(lo < hi) {
            int mid = lo + (hi-lo)/2;
            
            // no rotation
            if(nums[lo] < nums[hi])
                return nums[lo];
            
            // repeated sorted then this condition
            if(AreEqual(nums[lo], nums[mid], nums[hi])) {
                lo++;
                hi--;
            }
            // first half is sorted, so remove it from search space
            else if(nums[lo] <= nums[mid]) {
                lo = mid+1;
            }
            // else second half is sorted, so remove it from search space
            else {
                hi = mid;
            }
        }
        return nums[lo];
    }
    
    private bool AreEqual(int a, int b, int c) {
        return a == b && b == c;
    }
}
