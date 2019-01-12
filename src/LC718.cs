// 718 M https://leetcode.com/problems/maximum-length-of-repeated-subarray/description/
// Similar to longest common substring
public class Solution {
    public int FindLength(int[] A, int[] B) {
        int m = A.Length, n = B.Length;
        int[,] dp = new int[m+1,n+1];
        int max = 0;
        for(int i = 0; i <= m; i++) {
            for(int j = 0; j <= n; j++) {
                if(i == 0 || j == 0) dp[i,j] = 0;
                else if(A[i-1] == B[j-1]) {
                    dp[i,j] = 1 + dp[i-1,j-1];
                    max = Math.Max(max, dp[i,j]);
                }
                else
                    dp[i,j] = 0;
            }
        }
        
        return max;
    }
}
