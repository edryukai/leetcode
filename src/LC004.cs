// 4 H Median of two sorted arrays
// Sol: https://leetcode.com/problems/median-of-two-sorted-arrays/solution/
// Qn: https://leetcode.com/problems/median-of-two-sorted-arrays/description/

class Solution {
  public double MedianOfTwo(int[] A, int[] B) {
    int m = A.Length, n = B.Length;
    // ensure m <= n without loss of generality

    if(m > n) {
      int[] temp = A; A = B; B = temp;
      int tmp = m; m = n; n = tmp;
    }

    // lo and hi as iMin and iMax
    int iMin = 0, iMax = m, halfLen = (m+n+1)/2;
    
    while(iMin <= iMax) {
      int i = iMin + (iMax-iMin)/2;
      int j = halfLen - i;

      if(i < iMax && B[j-1] > A[i]) {
        iMin = i+1;
      }
      else if(i > iMin && A[i-1] > B[j]) {
        iMax = i-1;
      }
      else {
        // found i
        int maxLeft = 0;
        if(i == 0) maxLeft = B[j-1];
        else if(j == 0) maxLeft = A[i-1];
        else maxLeft = Math.Max(A[i-1], B[j-1]);

        if((m+n)%2 == 1) return maxLeft;

        int minRight = 0;
        if(i == m) minRight = B[j];
        else if(j == n) minRight = A[i];
        else minRight = Math.Min(B[j],A[i]);

        return (maxLeft + minRight)/2.0;
      }
    }
    return 0.0
  }
}
