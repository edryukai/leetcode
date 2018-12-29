// 832 E Flip Image (brute force simple)
// https://leetcode.com/problems/flipping-an-image/description/

class Solution {
    public int[][] flipAndInvertImage(int[][] A) {
        if(A == null) return null;
        for(int r = 0; r < A.length; r++) {
            A[r] = Flip(Reverse(A[r]));
        }
        return A;
    }
    
    private int[] Reverse(int[] a) {
        int i = 0;
        int l = a.length;
        while(i < l/2) {
            int temp = a[i];
            a[i] = a[l-1-i];
            a[l-1-i] = temp;
            i++;
        }
        return a;
    }
    
    private int[] Flip(int[] a) {
        for(int i = 0; i < a.length; i++) {
            if(a[i] == 1) a[i] = 0;
            else a[i] = 1;
        }
        return a;
    }
}
