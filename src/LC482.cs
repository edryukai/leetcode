// 482 E https://leetcode.com/problems/license-key-formatting/description/
// #tricky

public class Solution {
    public string LicenseKeyFormatting(string S, int K) {
        if(S == null || S.Length == 0)
            return S;

        int count = 0;
        StringBuilder sb = new StringBuilder();
        
        for(int i = S.Length-1; i >= 0; i--) {
            // Don't bother processing "-" since it doesn't matter
            if(S[i] != '-') {
                if(count == K) { sb.Append("-"); count = 0; }
                sb.Append(S[i].ToString().ToUpper());
                count++;
            }
        }
        
        return Reverse(sb.ToString());
    }
    
    public string Reverse(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}