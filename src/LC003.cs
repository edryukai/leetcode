// 3 M https://leetcode.com/problems/longest-substring-without-repeating-characters/description/
// Moving window
public class Solution {
    int[] count = new int[256];
    
    public int LengthOfLongestSubstring(string s) {
        if(s == null || s.Length == 0) return 0;
        int i = 0, max = 1;
        bool repeatchars = false;
        
        for(int j = 0; j < s.Length; j++) {
            char curr = s[j];
            if(count[curr] > 0) {
                repeatchars = true;
            }
            count[curr]++;
            
            while(repeatchars) {
                count[s[i]]--;
                // we moved past the char, but we still have a count, aka we moved past a repeated char
                if(count[s[i]] > 0) { 
                    repeatchars = false;
                }
                i++;
            }
            max = Math.Max(max,j-i+1);
        }
        
        return max;
    }
}