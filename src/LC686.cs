// https://leetcode.com/problems/repeated-string-match/description/
// Repeated string match 

/*
    Easy logic.
    TODO: Using KMP
*/

public class Solution {
    public int RepeatedStringMatch(string A, string B) {
        int count = 0;
        StringBuilder sb = new StringBuilder();

        while(sb.Count < B.Length) {
            sb.Append(A);
            count++;
        }

        if(sb.ToString().Contains(B)) return count;
        if(sb.Append(A).ToString().Contains(B)) return ++count;
        return -1;
    }
}