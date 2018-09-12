// 220 M https://leetcode.com/problems/contains-duplicate-iii/description/
//
// Lessons:
//          - If you are to check left window and right window, and if you have to do that for i = start to end,
//              you can just check the left window, since right window shall be covered as your i starts moving
//          - When we talk about array, and ranges, think BST/Segment Tree/BIT
// Idea:
//          - We need to be able to query the previous k values (previous, since we're only checking left window)
//              to find out if we have a value that satisfies given conditions
//          - BST is the easiest way to do that as operations can be done in logk time
//
// Space: O(k)
// Time: O(nlogk)


class Solution {
    public boolean containsNearbyAlmostDuplicate(int[] nums, int k, int t) {
        if(nums == null || nums.length == 0 || k <= 0) {
            return false;
        }
        
        final TreeSet<Long> bst = new TreeSet<>();
        
        for(int i = 0; i < nums.length; i++) {
            long l = (long) nums[i];
            
            // floor(x): greatest element in bst <= x
            // ceiling(x): smallest element in bst >= x
            Long floor = bst.floor(l);
            Long ceiling = bst.ceiling(l);

            // condition satisfied           
            if ((floor != null && l-floor <= t) ||
               (ceiling != null && ceiling-l <= t))
                return true;
            
            // add current number to bst
            bst.add(l);
            
            // keep only last k entries in bst
            if(i >= k) {
                bst.remove((long) nums[i-k]);
            }
        }
        
        return false;
    }
}