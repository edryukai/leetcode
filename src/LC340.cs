// https://leetcode.com/problems/longest-substring-with-at-most-k-distinct-characters/description/
// 340 H
// Moving Window

public class Solution {
    public int LengthOfLongestSubstringKDistinct(string s, int k) {
        int i = 0, j = 0, max = 0, distinct = 0;
        int[] count = new int[256];
        
        for(j = 0; j < s.Length; j++) {
            if(count[s[j]] == 0)
                distinct++;
            count[s[j]]++;
            
            // valid condition is that numDistinct == k
            // and we need to break out after the longest substring so we keep extending end of window
            // till we break out, i.e after numDistinct > k
            // at which point we will shorten start of window and make a valid one
            // and record the length
            while(distinct > k) {
                count[s[i]]--;
                if(count[s[i]] == 0) distinct--;
                i++;
            }
            
            // you could check for if(distinct == k) only then update length
            // but by principle, the moment distinct > k then we are resetting window
            // so all other numbers will be for distinct < k so it shouldn't matter
            max = Math.Max(max, j-i+1);       
        }
        return max;
    }
}
