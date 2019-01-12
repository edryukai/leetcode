// 187 - M - https://leetcode.com/problems/repeated-dna-sequences/description/
// Fixed moving window of size 10
// Straight forward logic
public class Solution {
    public IList<string> FindRepeatedDnaSequences(string s) {
        var seen = new HashSet<string>(); 
        var repeat = new HashSet<string>();
        for(int i = 0; i + 9 < s.Length; i++) {
            string ten = s.Substring(i,10);
            if(seen.Contains(ten)) {
                repeat.Add(ten);
            }
            else {
                seen.Add(ten);
            }
        }
        var result = new List<string>();
        foreach(string x in repeat) { result.Add(x); }
        
        return result;
    }
}