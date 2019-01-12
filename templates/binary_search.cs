// Generic template

// Step 0: Edge conditions
// Step 1: Define limits of your search space
// Step 2: while(lo < hi)
// Step 3: lo = mid+1, hi = mid in loop
// Step 4: Check for nums[lo]

public class Solution {
    public int SearchInsert(int[] nums, int target) {
      // Step 0
      if(nums == null || nums.Length == 0) return -1;
      // Step 1
      int lo = 0, hi = nums.Length-1;
        // Step 2
        while(lo < hi) {
            int mid = lo + (hi-lo)/2;
            if(nums[mid] == target) 
              return mid;
            else if(nums[mid] < target) 
              lo = mid+1;
            else 
              hi = mid;
        }
        // Step 4
        return nums[lo] == target ? lo : -1;
    }
}
