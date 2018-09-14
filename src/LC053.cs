// 53 E https://leetcode.com/problems/maximum-subarray/description/
// Space: O(1)
// Time: O(n)

public class Solution {
    public int MaxSubArray(int[] nums) {
        int localmax = 0, globalmax = nums[0];
        
        for(int i = 0; i < nums.Length; i++) {
            localmax += nums[i];
            globalmax = Math.Max(globalmax, localmax);
            if(localmax < 0) localmax = 0;
        }
        
        return globalmax;
    }
}