// 852 E https://leetcode.com/problems/peak-index-in-a-mountain-array/description/
// Very similar to 162. Works for duplicates too
public class Solution {
    public int PeakIndexInMountainArray(int[] A) {
        int lo = 0, hi = A.Length-1;
        while(lo < hi) {
            int mid = lo + (hi-lo)/2;
            if(A[mid] < A[mid+1])
                lo = mid+1;
            else
                hi = mid;
        }
        return lo;
    }
}
