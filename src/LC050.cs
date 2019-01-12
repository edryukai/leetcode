// 50 M https://leetcode.com/problems/powx-n/description/
// Edge cases:
// n = 0, then ans = 1
// n = 1, then ans = x
// n < 0, then ans = 1/MyPow(x,n)
// n = int_min (or negative infinity) then ans = 1 (if x = 1,-1) else 0
// Logic:
//          pow(x,n) = pow(x,n/2)*pow(x,n/2) if n is even
//                   = x * pow(x,n-1) if n is odd
public class Solution {
    public double MyPow(double x, int n) {
        if(n == 0) return 1;
        if(n == 1) return x;
        if(n == Int32.MinValue) { return x*x == 1 ? 1 : 0; }
        if(n < 0) return 1/MyPow(x,-n);
        if(n % 2 == 0) {
            double y = MyPow(x,n/2);
            return y*y;
        }
        else return x*MyPow(x,n-1);
    }
}
