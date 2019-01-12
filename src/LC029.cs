// Vanilla code for division using addition
// The actual problem deals with shitty edge cases and that will be down below

// Find largest multiple such that divisor * multiple <= dividend
// aka multiple <= dividend/divisor
// we can do this using binary search
private long LDivide(long dividend, long divisor) {
    if(dividend < divisor) return 0;    // base case

    long quotient = 1, sum = divisor;
    while((sum + sum) < dividend) {
        sum += sum;
        quotient += quotient;
    }

    return quotient + LDivide(dividend-sum, divisor);
}

// 29 M Divide two integers
// Important edge cases:
// 1. Division by 0
// 2. Taking care of sign
// 3. Dividend < Divisor
// 4. Converting dividend and divisor into long in case we have Int32.MinValue (since we are dealing with +ve division and assigning sign later)
// 5. If quotient is > Int32.MaxValue, we box it to Int32.MaxValue (similarly for minvalue if sign is -1)
public class Solution {
    public int Divide(int dividend, int divisor) {
        int sign = 1;
        // divide irrespective of sign and later assign sign
        if(dividend < 0 ^ divisor < 0) 
            sign = -1;

        long ldividend = Math.Abs((long)dividend);
        long ldivisor = Math.Abs((long)divisor);

        // Edge cases
        if(ldivisor == 0) return Int32.MaxValue;
        if(ldividend == 0 || (ldividend < ldivisor)) return 0;

        long lres = LDivide(ldividend, ldivisor);
        int res;

        // Handle overflow
        if(lres > Int32.MaxValue) {
            return sign == -1 ? Int32.MinValue : Int32.MaxValue;
        }
        else {
            res = Convert.ToInt32(sign * lres);
        }

        return res;
    }

    private long LDivide(long ldividend, long ldivisor) {
        // Recursion exit
        if(ldividend < ldivisor)
            return 0;

        /*
            Find the largest multiple such that divisor * multiple <= dividend
            We can proceed in a binary search-ish way by moving with 1,2,4,8,...,2^x for perf
        */

        long multiple = 1;
        long sum = ldivisor;

        while((sum + sum) <= ldividend) {   // by assigning multiple = 1, we already handled the case of '1'. So we can proceed with 2, 4, ....
            sum += sum;
            multiple += multiple;
        }

        // Look for additional values of multiple from remainder
        return multiple + LDivide(ldividend - sum, ldivisor);
    }
}
