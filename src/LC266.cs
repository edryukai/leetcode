// 266 E https://leetcode.com/problems/palindrome-permutation/description/
// Edge cases: case sensitive/insensitive ?
// Logic: only one word can appear odd number of times max
// Space: O(n)
// Time: O(n)

public class Solution {
    public bool CanPermutePalindrome(string s) {
        if(s == null || s.Length == 0) return true;
        
        int sl = s.Length;
        var counts = new Dictionary<char,int>();
        for(int i = 0; i < sl; i++) {
            if(counts.ContainsKey(s[i]))
                counts[s[i]] += 1;
            else
                counts[s[i]] = 1;
        }
        
        int numOdd = 0;
        foreach(int x in counts.Values) {
            if(x % 2 == 1)
                numOdd += 1;
            
            if(numOdd >= 2)
                return false;
        }
        
        return true;
    }
}