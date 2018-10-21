// https://leetcode.com/problems/backspace-string-compare/description/
// Backspace string compare

/*
    Sol-1:  O(n) time, O(n) space 
    Using simple stack
 */
public class Solution {
    public bool BackspaceCompare(string S, string T) {
        var st = new Stack<char>();
        
        for(int i = 0; i < S.Length; i++) {
            if(S[i] != '#') st.Push(S[i]);
            else {
                if(st.Count != 0) // imp to check if stack has elements before you pop
                    st.Pop();
            }
        }
        string s_fin = string.Join("", st.ToArray());
        
        st = new Stack<char>();
        for(int i = 0; i < T.Length; i++) {
            if(T[i] != '#') st.Push(T[i]);
            else {
                if(st.Count != 0)
                    st.Pop();
            }
        }
        string t_fin = string.Join("", st.ToArray());
        
        return s_fin.Equals(t_fin);
    }
}

/*
    Sol-2: O(n) time, O(1) space
 */

public class Solution {
    public bool BackspaceCompare(string S, string T) {
        int i = s.Length-1, j = T.Length-1;
        
        while(true) [
            for(int end = 0; i >= 0 && (end > 0 || S[i] == '#'); i--)
                end += S[i] == '#' ? 1 : -1;
            
            for(int end = 0; j >= 0 && (end > 0 || T[j] == '#'; j--))
                end += T[j] == '#' ? 1 : -1;
            
            if(i >= 0 && j >= 0 && S[i] == T[j]) {
                i--; j--;
            }
            else {
                return i == -1 && j == -1;
            }
        ]
    }
}