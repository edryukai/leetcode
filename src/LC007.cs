// 7 E https://leetcode.com/problems/reverse-integer/description/
// Edge cases: negative numbers, reverse going out of bounds
// Space: O(1) 
// Time: O(n) where n is length of given int. Since max range for int32 is 4B, we have 10 digits. So can be considered O(1)

public class Solution {
    public int Reverse(int x) {
        if(x == 0) return 0;
        bool isneg = x < 0;
        
        int res = 0;
        while(x != 0) {
            int tail = x % 10;
            int temp = res * 10 + tail;
            // catch reverse going out of bounds
            if((temp - tail)/10 != res)  
                return 0;

            res = temp;
            x = x/10;
        }
        
        return res;
    }
}