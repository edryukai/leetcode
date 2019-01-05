// 387 E First non duplicate character in string index
public class Solution {
    public int FirstUniqChar(string s) {
        var encountered = new HashSet<char>();
        var duplicates = new HashSet<char>();
        foreach(char x in s.ToCharArray()) {
            if(encountered.Contains(x))
                duplicates.Add(x);
            encountered.Add(x);
            
        }
        
        int index = 0;
        foreach(char x in s.ToCharArray()) {
            if(!duplicates.Contains(x))
                return index;
            else
                index++;
        }
        return -1;
    }
}
