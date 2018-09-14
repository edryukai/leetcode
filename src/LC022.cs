// 22 M https://leetcode.com/problems/generate-parentheses/description/
// Space: O(1) while not considering stack space
// Time: O(n) since we're generating a max of 2n-1 combinations

public class Solution {
    public IList<string> GenerateParenthesis(int n) {
        IList<string> res = new List<string>();
        if(n <= 0) return res;
        Backtrack(n, res, "", 0, 0);
        return res;
    }
    
    public void Backtrack(int n, IList<string> res, string temp, int open, int closed) {
        // exit condition
        if(open > n || closed > n)
            return;
        
        // success condition
        else if(open == closed && open == n) {
            res.Add(temp);
        }
        
        else {
            Backtrack(n, res, temp + "(", open+1, closed);
            // we add open braces first, ensuring that a corresponding closed brace could come only after the open brace
            // and we make sure we don't add more closed braces than we have open braces
            if(open > closed) {
                Backtrack(n, res, temp + ")", open, closed+1);
            } 
        }
    }
}