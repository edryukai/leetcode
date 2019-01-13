// 788 E https://leetcode.com/problems/rotated-digits/description/
// 0,1,8 rotate to themselves
// 2,5,6,9 rotate 
// so any number that contains 3,4,7 are invalid
// we need to find numbers from 1 to N that:
//      - don't contain 3,4,7
//      - contain at least one of 2,5,6,9
//      - 0,1,8 aren't really doing anything

public class Solution {
    HashSet<int> valid = new HashSet<int>() {2,5,6,9};
    HashSet<int> invalid = new HashSet<int>() {3,4,7};
    
    public int RotatedDigits(int N) {    
        int count = 0;
        for(int i = 1; i <= N; i++) {
            if(isValid(i))
                count++;
        }
        return count;
    }
    
    private bool isValid(int i) {
        bool containsAtLeastSingleValidDigit = false;
        while(i > 0) {
            int curr = i % 10;
            if(valid.Contains(curr)) {
                i = i/10;
                containsAtLeastSingleValidDigit = true;
            }
            else if(invalid.Contains(curr))
                return false;
            else
                i = i/10;
        }
        return containsAtLeastSingleValidDigit;
    }
}