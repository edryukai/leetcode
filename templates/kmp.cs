// If there's a match, go ahead
// Else, find the next correct matching character using lps array (by skipping a suffix that's also a prefix)
// Complexity: 
//              Pattern - m, Text - n
//              Space: O(m)
//              Time: O(m+n)

public bool KMP(char[] text, char[] pattern) {
    int lps[] = computeLps(pattern);
    int i = 0, j = 0;

    while(i < text.Length && j < pattern.Length) {
        if(text[i] == pattern[j]) {
            i++;
            j++;
        }
        else {
            if(j != 0) {
                j = lps[j-1];
            }
            else
                i++;
        }
    }

    if(j == pattern.Length)
        return true;

    return false;
}

// Compute LPS array
// Logic: We're trying to find a partial prefix match in the suffix
// so that those characters can be skipped when doing next match

private int[] ComputeLps(char[] pattern) {
    int[] lps = new int[pattern.Length];
    int j = 0;

    for(int i = 1; i < pattern.Length;) {
        if(pattern[i] == pattern[j]) {
            lps[i] = j+1;
            i++;
            j++;
        }
        else {
            if(j != 0) {
                j = lps[j-1];
            }
            else {  
                // j == 0
                // This happens when we kept doing j = lps[j-1] and eventually landed at the back of 
                // lps array but still couldn't find a pattern match between i and j
                // So we set lps[i] to 0 and increment i. j starts at index 0
                lps[i] = 0;
                i++;
            }
        }
    }
    return lps;
}
