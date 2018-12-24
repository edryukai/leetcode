// 169 E https://leetcode.com/problems/majority-element/description/
// The question says majority element will always exist, logic will change if it doesn't. We can't just return maj
// Time: O(n)
// Space: O(1)

public class Solution {
    public int MajorityElement(int[] nums) {
        int cnt = 1, maj = nums[0];
        
        for(int i = 1; i < nums.Length; i++) {
            if(nums[i] == maj) {
                cnt++;
            }
            else {
                cnt--;
                if(cnt == 0) {
                    maj = nums[i];
                    cnt = 1;    // setting cnt for current candidate majority element
                }
            }
        }
        
        return maj;
    }
}
