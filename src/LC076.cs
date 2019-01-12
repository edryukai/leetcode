// 76 H Min window substring
// https://leetcode.com/problems/minimum-window-substring/description/
// if we encountered a char that's in T, and we haven't met the min char match yet, increment match counter
// in any case, we will increment windowcount
// we only need to decrease it if start is moved to right
public class Solution {
    int[] tcount = new int[256];
    int[] windowcount = new int[256];
    
    public string MinWindow(string s, string t) {
        string res = "";
        int match = 0, i = 0, minLen = Int32.MaxValue;

        foreach(char x in t) {
            tcount[x]++;
        }

        for(int j = 0; j < s.Length; j++) {
            char curr = s[j];

            if(tcount[curr] > 0) {
                if(windowcount[curr] < tcount[curr]) {
                    match++;
                }
            }
            windowcount[curr]++;
            
            // the moment we have a valid window, check if it's min and then break validity
            if(match == t.Length) {
                // invalidate window
                while(i < s.Length && match == t.Length) {
                    windowcount[s[i]]--;
                    // decreast match if we moved past a valid char
                    if(tcount[s[i]] > 0 && windowcount[s[i]] < tcount[s[i]])     
                        match--;
                    i++;
                }
                // store the current valid candidate
                string candidate = s.Substring(i-1,j-(i-1)+1);
                if(candidate.Length < minLen) { res = candidate; minLen = res.Length; }
            }
        }

        return minLen == Int32.MaxValue ? "" : res;
    }
}