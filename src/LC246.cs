// 246 E Check if number is strobogrammatic
// https://leetcode.com/problems/strobogrammatic-number/description/

public class Solution {
    public bool IsStrobogrammatic(string num) {
        var map = new Dictionary<char,char>();
        map['0'] = '0';
        map['1'] = '1';
        map['8'] = '8';
        map['6'] = '9';
        map['9'] = '6';

        // when you turn by 180 degrees, number gets reversed
        // some digits get inverted (6,9,0) and some stay the same (1,8) and some become invalid
        // So upside down mapping should be same as reverse of the number for a num to be strobogrammatic
        var sb = new StringBuilder();

        char[] c = num.ToCharArray();
        for(int i = 0; i < c.Length; i++) {
            if(!map.ContainsKey(c[i]))
                return false;
            else {
                sb.Append(map[c[i]].ToString());
            }
        }

        return sb.ToString().Equals(Reverse(num));
    }

    public string Reverse(string s) {
        var sb = new StringBuilder();
        for(int i = s.Length-1; i >= 0; i--) {
            sb.Append(s[i].ToString());
        }
        return sb.ToString();
    }
}
