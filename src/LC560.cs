// 560 M Number of subarrays that sum to K
// Similar to finding if there's a subarray that sums to K
// Maintain prefix sums in dictionary, and count of number of times that prefixSum has occurred (coz there could be -ve elements)
// If dict contains prefixSum-k, it means we have a window that adds to k
// Just keep maintining count
// Imp edge case: d[0] = 1 (coz empty array means sum == 0)

public class Solution {
    public int SubarraySum(int[] nums, int k) {
        // maintain count of prefix sum and how many different subarrays caused it
        var d = new Dictionary<int,int>();
        // very very imp base case
        d[0] = 1;   
        
        int prefixSum = 0;
        int res = 0;
        for(int i = 0; i < nums.Length; i++) {
            prefixSum += nums[i];
            if(d.ContainsKey(prefixSum - k)) {
                res += d[prefixSum-k];
            }
            
            if(d.ContainsKey(prefixSum))
                d[prefixSum] += 1;
            else
                d[prefixSum] = 1;
        }
        return res;
    }
}
