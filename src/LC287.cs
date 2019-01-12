/*
    Given the numbers are in range 1-n, we can treat this as a problem of finding starting point of circle in a linked list
*/
public class Solution {
    public int FindDuplicate(int[] nums) {
        if(nums == null || nums.Length <= 1) return -1;
        
        int fast, slow;
        slow = nums[0];
        fast = nums[nums[0]];
        
        while(slow != fast) {
            slow = nums[slow];
            fast = nums[nums[fast]];
        }
        
        fast = 0;
        while(slow != fast) {
            slow = nums[slow];
            fast = nums[fast];
        }
        
        
        return slow;
    }
}
