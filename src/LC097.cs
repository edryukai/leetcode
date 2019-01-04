// 97 H https://leetcode.com/problems/interleaving-string/description/
// Logic is simple really
// s3 has to be an interleaving of s1 and s2
// so define state as:
//      dp[i,j] => s3[0..i+j] is an interleaving from s1[0..i] and s2[0..j]
//      So dp[i,j] from previous states is simple:
//          it can't come from dp[i-1,j-1] coz it means we are skipping two chars, one from each of s1 and s2
//          if s3[i+j] == s1[i] then dp[i,j] = dp[i-1,j]
//          else if s3[i+j] == s2[j] then dp[i,j] == dp[i,j-1]
//          if it's not matching any then dp[i,j] is false

public class Solution {
    public bool IsInterleave(string s1, string s2, string s3) {
        int m = s1.Length, n = s2.Length;
        if(s3.Length != m + n) return false;
        
        // state: s3[0 .. i+j+1] is an interleaving of s1[0..i] and s2[0..j]
        bool[,] dp = new bool[m+1,n+1];
        dp[0,0] = true;
        
        for(int i = 0; i <= m; i++) {
            for(int j = 0; j <= n; j++) {
                if(i == 0 && j == 0)
                    dp[i,j] = true;
                else if(i == 0)
                    dp[i,j] = dp[i,j-1] && s2[j-1] == s3[i+j-1];
                else if(j == 0)
                    dp[i,j] = dp[i-1,j] && s1[i-1] == s3[i+j-1];
                else
                    dp[i,j] = (dp[i-1,j] && s3[i+j-1] == s1[i-1]) || (dp[i,j-1] && s3[i+j-1] == s2[j-1]);
            }
        }
        
        return dp[m,n];
    }
}
