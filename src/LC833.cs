// 833 M https://leetcode.com/problems/find-and-replace-in-string/description/
// Find and replace in string
//
// Idea: I don't have to realistically modify the string, given that there are no clashes, as per the question
//       So I can just scan the source string, and whenever I encounter an index in the source string that has to be replaced,
//          I pick the corresponding value from the target string and replace it. I advance the pointer by source[i].Length
//          because those many characters in source string would've been processed.
// Space: O(n), time: O(n)

public class Solution {
    public string FindReplaceString(string S, int[] indexes, string[] sources, string[] targets) {
        StringBuilder sb = new StringBuilder();
        
        // key => the index in source string where sources[i] occurs (if valid)
        // value => i
        // we need this to track index between indexes[], sources[], targets[]
        var d = new Dictionary<int,int>();
        
        for(int v = 0; v < indexes.Length; v++) {
            // add only valid entries. i.e source string should have the mentioned substring at the given index
            if(S.Substring(indexes[v], sources[v].Length).Equals(sources[v])) {
                d[indexes[v]] = v;
            }
        }
        
        int i = 0;
        while(i < S.Length) {
            if(d.ContainsKey(i)) {
                sb.Append(targets[d[i]]);
                i += sources[d[i]].Length;  // advance pointer by the length of substring that has to be replaced
            }
            else {
                sb.Append(S[i].ToString());
                i += 1;
            }
        }
        return sb.ToString();
    }
}
