// https://leetcode.com/problems/monotonic-array/
// Space: O(1)
// Time: O(n)

public class Solution {
    public bool IsMonotonic(int[] A) {
        bool toneSet = false;
        bool increasing = false;
        bool decreasing = false;
        
        for(int i = 1; i < A.Length; i++) {
            if(A[i] != A[i-1]) {
                if(!toneSet) {
                    toneSet = true;
                    increasing = (A[i] > A[i-1]);
                    decreasing = !increasing;
                }
                else {
                    if(increasing && A[i] < A[i-1]) {
                        return false;
                    }
                    else if(decreasing && A[i] > A[i-1]) {
                        return false;
                    }
                }
            }
        }
        
        return true;
    }
}