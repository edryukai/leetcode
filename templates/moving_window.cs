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
