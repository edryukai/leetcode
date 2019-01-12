// 859 E https://leetcode.com/problems/buddy-strings/description/
// Edge cases are interesting:
//  - "aa", "aa" should return true
//  - "ab", "ab" should return false
//  - which means if the num_mismatch != 2 with our logic, we should see if we can interchange any 2 letters that are the same
public class Solution {
    public bool BuddyStrings(string A, string B) {
        int first_mismatch_index, second_mismatch_index;
        char as_mismatch = '0', bs_mismatch = '0';
        int num_mismatch = 0;
        
        if(A == null ^ B == null) return false;
        if(A.Length != B.Length) return false;
        
        for(int i = 0; i < A.Length; i++) {
            if(A[i] != B[i]) {
                num_mismatch++;
                if(num_mismatch > 2) return false;
                if(num_mismatch == 1) {
                    as_mismatch = A[i];
                    bs_mismatch = B[i];
                    continue;
                }
                else if(num_mismatch == 2) {
                    if(A[i] != bs_mismatch || B[i] != as_mismatch)
                        return false;
                }
            }
        }
        
        if(num_mismatch == 0) {
            var h = new HashSet<char>();
            foreach(char x in A) {
                if(h.Contains(x))
                    return true;
                h.Add(x);
            }
        }
        
        return num_mismatch == 2;
    }
}