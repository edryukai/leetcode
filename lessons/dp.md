## [562](https://leetcode.com/problems/longest-line-of-consecutive-one-in-matrix/description/) Longest line of consecutive 1s
* Matrix dp
* 1s should either be horizontal, vertical, diag or anti diag
* So `dp[i,j,k] = new dp[m,n,4]` where direction is the third dimension and we save results per dimension
* Note that in DP when we are calculating `dp[i,j]`, everything we use to compute that must already be calculated so here whatever comes `south/down` will not be considered into `current`