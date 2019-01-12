// Increase end in a for loop till we break out of a valid window (i.e, reach a valid window first, and then break out of it)
// Then in a while loop, move the start ahead till your window is valid again
// Track your result
public int MovingWindow(string s) {
    // increase end in a for loop
    int i = 0;
    for(int j = 0; j < s.Length; j++) {
        // update the state as and when j moves ahead

        while(windowIsInvalid(s,i,j)) {
            // update state
            // move start
            i++;
        }

        // update final state
    }
}



// Ex: Longest substring with at most two distinct characters
public int MovingWindow(string s) {
    if(s == null || s.Length == 0) return 0;
    int start = 0, maxLen = 0, numDistinct = 0;
    int[] count = new int[256];

    // Increase end of window by 1 at each step
    for(int end = 0; end < s.Length; end++) {
        int curr = s[end] - '0';
        
        if(count[curr] == 0) { 
          numDistinct++; 
        }
        count[curr]++;

        // once window becomes valid, we invalidate it with a while loop by moving the start of window
        // in current example, we need longest substring with at most 2 distinct characters
        // So we keep extending the window till numDistinct becomes > 2
        // Once we reach that point, we have just broken out of our valid window and we need to fix it
        while(numDistinct > 2) {
            int curr_start = s[start]-'0';
            count[curr_start]--;
            if(count[curr_start] == 0) 
                numDistinct--;
            i++;
        }
        maxLen = Math.Max(maxLen, end-start+1);
    }
    return maxLen;
}

// Longest substring with at most k distinct characters
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

            // you could check for if(distinct <= k) only then update length
            // but by principle, the moment distinct > k then we are resetting window
            // so all other numbers will be for distinct < k so it shouldn't matter
            max = Math.Max(max, j-i+1);
        }
        return max;
    }
}

// Min window substring

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
                // store the current valid candidate (note that we have moved i one place ahead from a valid position)
                string candidate = s.Substring(i-1,j-(i-1)+1);
                if(candidate.Length < minLen) { res = candidate; minLen = res.Length; }
            }
        }

        return minLen == Int32.MaxValue ? "" : res;
    }
}


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