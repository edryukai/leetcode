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


// Aliter: O(n) time, O(1) space
// Idea:
//      1. Scan from end
//      2. If count >= 0 && curr != '#' skip
//      3. If count == 0 and different chars, return false
//      4. If #, count++
//      5. If one ends and the other has count == 0 && has some chars left, return false
//      6. Else return true
//

public class Solution {
    public bool BackspaceCompare(string S, string T) {
        int i = S.Length-1;
        int j = T.Length-1;
        int countS = 0;
        int countT = 0;

        while(i >= 0 || j >= 0) {
          // scan S
          // skip chars if countS > 0 or if we have a #
          while(i >= 0 && (countS > 0 || S[i] == '#')) {
              if(S[i] == '#') countS++;
              else countS--;
              i--;
          }
          char left = i < 0 ? '@' : S[i];

          // scan T
          while(j >= 0 && (countT > 0 || (T[j] == '#'))) {
              if(T[j] == '#') countT++;
              else countT--;
              j--;
          }
          char right = j < 0 ? '@' : T[j];

          if(left != right) return false;
          i--;
          j--;
        }

        return true;
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
