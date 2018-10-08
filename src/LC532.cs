// 532 E https://leetcode.com/problems/k-diff-pairs-in-an-array/description/
// Logic:
//          - If k == 0 then return the number of duplicate elements
//          - Since we want 'unique' k diff pairs, instead of scanning original array, we scan the keys in dictionary
//              and also uniqueness means we need to do only a 'forward' scan

public class Solution {
    public int FindPairs(int[] nums, int k) {
        if(k < 0)
            return 0;
        
        var ele = new Dictionary<int,int>();
        
        foreach(int x in nums) {
            if(ele.ContainsKey(x))
                ele[x] += 1;
            else
                ele[x] = 1;
        }
        
        int count = 0;
        
        foreach(var kvp in ele) {
            if(k == 0) {
                if(kvp.Value >= 2)
                    count++;
            }
            else {
                if(ele.ContainsKey(kvp.Key + k))
                    count++;
            }
        }
        
        return count;
    }
}