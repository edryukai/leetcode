// https://leetcode.com/problems/sentence-similarity/description/
// Since transitivity doesn't hold according to the question we don't have to union-find this
// O(n) time and space
public class Solution {
    public bool AreSentencesSimilar(string[] words1, string[] words2, string[,] pairs) {
        if(words1.Length != words2.Length) return false;
        
        var d = new Dictionary<string,List<string>>();
        for(int i = 0; i < pairs.GetLength(0); i++) {
            // note that transitivity is false
            if(!d.ContainsKey(pairs[i,0]))
                d[pairs[i,0]] = new List<string>();
            
            d[pairs[i,0]].Add(pairs[i,1]);
        }
        
        int j = 0;
        while(j < words1.Length) {
            if(words1[j].Equals(words2[j]) 
              || (d.ContainsKey(words1[j]) && d[words1[j]].Contains(words2[j]))
              || (d.ContainsKey(words2[j]) && d[words2[j]].Contains(words1[j]))) 
            {
                j++;
                continue;
            }
            else
                return false;
        }
        
        return true;
    }
}
