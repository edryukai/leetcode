// 20 E https://leetcode.com/problems/valid-parentheses/
// Space: O(n)
// Time: O(n)
// Edge cases:
//              1. Always check if stack has elements before trying to pop
//              2. After processing input string, check if stack has any remaining elements

public class Solution {
    public bool IsValid(string s) {
        Dictionary<string,string> opening = new Dictionary<string,string>();
        Stack<string> st = new Stack<string>();
        opening["("] = ")";
        opening["["] = "]";
        opening["{"] = "}";
        
        for(int i = 0; i < s.Length; i++)
        {
            if(opening.ContainsKey(s[i].ToString()))
                st.Push(s[i].ToString());
            else
            {
                // not found any element in stack to correspond
                if(st.Count == 0)
                    return false;
                
                // if corresponding element matches
                string pop = st.Pop();
                if(!opening[pop].Equals(s[i].ToString()))
                    return false;
            }
        }
        
        // if stack is empty, everything was matched
        return st.Count == 0;
    }
}