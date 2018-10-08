// 69 E https://leetcode.com/problems/sqrtx/description/
public class Solution {
    public int MySqrt(int x) {
        if(x == 0) return 0;
        if(x == 1) return 1;
        
        int lo = 1, hi = x, mid = 0; 
        
        while(lo < hi) {
            mid = lo + (hi-lo)/2;
            
            // Found => mid*mid <= x and (mid+1)*(mid+1) > x
            if(mid <= x/mid && (mid+1) > x/(mid+1))
                return mid;
            else if(mid < x/mid)
                lo = mid+1;
            else 
                hi = mid-1;
        }
        
        return lo;
    }
}