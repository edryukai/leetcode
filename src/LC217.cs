// 217 E https://leetcode.com/problems/contains-duplicate/description/
// Space: O(n)
// Time: O(n)

public class Solution {
    public bool ContainsDuplicate(int[] nums) {
        HashSet<int> h = new HashSet<int>();
        foreach(int x in nums) {
            if(h.Contains(x))
                return true;
            h.Add(x);
        }        
        return false;
    }
}