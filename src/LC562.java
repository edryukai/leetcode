// 562 M https://leetcode.com/problems/longest-line-of-consecutive-one-in-matrix/description/

public int longestLine(int[][] M) {
    int n = M.length, max = 0;
    if (n == 0) return max;
    int m = M[0].length;

    // because we have to store per direction, it also becomes a dimension
    int[][][] dp = new int[n][m][4];

    // 4 directions
    // 0 => left
    // 1 => top
    // 2 => north-west
    // 3 => north-east
    // note that south comes later (after current)
    for (int i=0;i<n;i++) 
        for (int j=0;j<m;j++) {
            if (M[i][j] == 0) continue;
            for (int k=0;k<4;k++) dp[i][j][k] = 1;
            if (j > 0) dp[i][j][0] += dp[i][j-1][0]; // horizontal line
            if (j > 0 && i > 0) dp[i][j][1] += dp[i-1][j-1][1]; // anti-diagonal line
            if (i > 0) dp[i][j][2] += dp[i-1][j][2]; // vertical line
            if (j < m-1 && i > 0) dp[i][j][3] += dp[i-1][j+1][3]; // diagonal line
            max = Math.max(max, Math.max(dp[i][j][0], dp[i][j][1]));
            max = Math.max(max, Math.max(dp[i][j][2], dp[i][j][3]));
        }
    return max;
}