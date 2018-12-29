// E 13 Roman to Integer

public class Solution {
    public int RomanToInt(string s) {
        var edgecases = new Dictionary<string,int>();
        edgecases["IV"] = 4;
        edgecases["IX"] = 9;
        edgecases["XL"] = 40;
        edgecases["XC"] = 90;
        edgecases["CD"] = 400;
        edgecases["CM"] = 900;

        var conv = new Dictionary<string,int>();
        conv["I"] = 1;
        conv["V"] = 5;
        conv["X"] = 10;
        conv["L"] = 50;
        conv["C"] = 100;
        conv["D"] = 500;
        conv["M"] = 1000;

        int sum = 0;
        for(int i = 0; i < s.Length; ) {
            if(i < s.Length-1 && edgecases.ContainsKey(s.Substring(i,2))) {
                sum += edgecases[s.Substring(i,2)];
                i += 2;
            }
            else {
                sum += conv[s[i].ToString()];
                i += 1;
            }
        }

        return sum;
    }
}
