// Imp tip:
// matrix[x,y] = a[x*c + y]
// a[x] = matrix[x/c, x%c]

// 74 M https://leetcode.com/problems/search-a-2d-matrix/description/
public class Solution {
    public bool SearchMatrix(int[,] matrix, int target) {
        int r = matrix.GetLength(0);
        int c = matrix.GetLength(1);
        if(r == 0 || c == 0) return false;
        
        int lo = 0, hi = r*c-1;
        while(lo < hi) {
            int mid = lo + (hi-lo)/2;
            int curr = matrix[mid/c,mid%c];
            if(curr == target)
                return true;
            else if(curr < target)
                lo = mid+1;
            else
                hi = mid;
        }
        return matrix[lo/c,lo%c] == target;
    }
}
