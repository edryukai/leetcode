// 53 E https://leetcode.com/problems/maximum-subarray/description/
// Edge cases: What if all numbers are negative?
// It's important to init globalMax to arr[0]
// And everytime localMax < 0 we set it back to 0 coz there is no point in adding -ve numbers and decreasing the value further
// Time: O(n)
// Space: O(1)

public class Solution {
    public int MaxSubArray(int[] nums) {
        int localMax = 0, globalMax = nums[0];
        for(int i = 0; i < nums.Length; i++) {
            localMax += nums[i];
            globalMax = Math.Max(globalMax, localMax);
            if(localMax < 0) localMax = 0;
        }
        return globalMax;
    }
}
