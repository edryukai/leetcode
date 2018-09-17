// 905 E https://leetcode.com/problems/sort-array-by-parity/description/
// Time: O(n) Space: O(1)

public class Solution {
    public int[] SortArrayByParity(int[] A) {
        int sorted = 0;
        int i = 0;
        int max = A.Length;
        
        while(i < max) {
            if(A[i] % 2 == 0) {
                int temp = A[sorted];
                A[sorted++] = A[i];
                A[i] = temp;
            }
            i++;
        }
        
        return A;
    }
}