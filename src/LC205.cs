// 205 E https://leetcode.com/problems/isomorphic-strings/description/
// Space: O(1) since at best we encounter 26 chars
// Time: O(n)
// Edge cases:
//              1. Case insensitivity or not
//              2. If our char from 't' is already mapped to something else in 's', return false
public class Solution {
    public bool IsIsomorphic(string s, string t) {
        var d = new Dictionary<char,char>();
        var encountered = new HashSet<char>();
        for(int i = 0; i < s.Length; i++) {
            char src = s[i], dest = t[i];
            if(d.ContainsKey(src)) {
                if(dest != d[src])
                    return false;
            }
            else {
                // if our dest has been mapped to something else already
                if(encountered.Contains(dest))
                    return false;
                d[src] = dest;
                encountered.Add(dest);
            }
        }
        
        return true;
    }
}