// 804 E Bruteforce
// https://leetcode.com/problems/unique-morse-code-words/description/

public class Solution {
    public string[] morse = new string[] {".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."};
    
    public int UniqueMorseRepresentations(string[] words) {
        if(words == null || words.Length == 0)
            return 0;
        
        var wset = new HashSet<string>();
        foreach(string w in words) {
            wset.Add(Transform(w));
        }
        
        return wset.Count;
    }
    
    private string Transform(string s) {
        StringBuilder sb = new StringBuilder();
        foreach(char c in s.ToCharArray()) {
            sb.Append(morse[c-'a']);
        }
        return sb.ToString();
    }
}
