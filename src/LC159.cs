// https://leetcode.com/problems/longest-substring-with-at-most-two-distinct-characters/
// Substring at most 2 distinct chars

// Algo:
// Moving Window
// Time Complexity: O(n)
// Space Complexity: O(n)

public class Solution {
    public int LengthOfLongestSubstringTwoDistinct(string s) {
        if(s == null || s.Length == 0) return 0;
        int i = 0, numDistinct = 0, maxLen = 0;
        int[] count = new int[256];
        
        // Increase 'end' of window by 1 at each step
        for(int j = 0; j < s.Length; j++) {
            if(count[s[j]] == 0)
                numDistinct++;
            count[s[j]]++;
            
            // while window is invaid (after becoming valid. which is the key point. numDistinct > 2 takes care of this), make it valid
            while(numDistinct > 2) {
                count[s[i]]--;
                if(count[s[i]] == 0)
                    numDistinct--;
                
                i++;
            }
            // update maxlen of valid window
            maxLen = Math.Max(maxLen, j-i+1);
        }
        
        return maxLen;
    }
}