// 219 E https://leetcode.com/problems/contains-duplicate-ii/description/
// Space O(n)
// Time O(n)

public class Solution {
    public bool ContainsNearbyDuplicate(int[] nums, int k) {
        var d = new Dictionary<int,int>();
        
        for(int i = 0; i < nums.Length; i++) {
            if(d.ContainsKey(nums[i])) {
                int existingIndex = d[nums[i]];
                int currentIndex = i;
                // update index in dictionary to contain latest index
                d[nums[i]] = i;
                if(currentIndex - existingIndex <= k)
                    return true;
            }
            else
                d[nums[i]] = i;
        }       
        return false;
    }
}