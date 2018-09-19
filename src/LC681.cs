// 681 M https://leetcode.com/problems/next-closest-time/description/
// Edge cases: If no greater permutation found, come in a circle (ex: 23:59)
//             In almost all questions that involve a clock, this happens
// Time: O(1) since 4 digits in input
// Space: O(1) since 4 digits in input
// Logic:
//          1. There are a max of 4 digits in input, to find next greatest number, form all possible permutations of the four
//          2. Find smallest permutation greater than current number
//          3. If no such permutation is found, return the smallest of all permutations (as we're coming circular around clock)

public class Solution {
    public string NextClosestTime(string time) {
        string[] split = time.Split(':');
        
        int hh = Convert.ToInt32(split[0]),
            mm = Convert.ToInt32(split[1]);
        
        // convert "19:35" to 1935
        int num_without_colon = Convert.ToInt32(split[0] + split[1]);
        
        int[] digits = new int[4];
        digits[0] = hh/10;
        digits[1] = hh%10;
        digits[2] = mm/10;
        digits[3] = mm%10;
        
        // Find all possible permutations using the four digits
        string[] possiblePermutations = AllPermutations(digits);
        Array.Sort(possiblePermutations, new StringSorter());
        
        // If we find a smallest number greater than given number, that's our answer
        // Otherwise, we're coming round the clock (aka from 00:00) so we return overall smallest number
        string smallestGreaterStr = FindSmallestGreater(possiblePermutations, num_without_colon);
        
        if(smallestGreaterStr != "-1") {
            // convert back something like "1935" to "19:35"
            return FormatForOutput(smallestGreaterStr);
        }

        return FormatForOutput(possiblePermutations[0]);
    }
    
    // s will be of length 4
    private string FormatForOutput(string s) {
        return s.Substring(0,2) + ":" + s.Substring(2,2);
    }
    
    // Smallest number greater than x
    private string FindSmallestGreater(string[] a, int num) {
        for(int i = 0; i < a.Length; i++) {
            if(Convert.ToInt32(a[i]) > num)
                return a[i];
        }
        return "-1";
    }
    
    private string[] AllPermutations(int[] digits) {
        List<string> perms = new List<string>();
        Array.Sort(digits);
        Backtrack(digits, perms, "");
        return perms.ToArray();
    }
    
    private void Backtrack(int[] a, List<string> result, string temp) {
        if(temp.Length == 4) {
            // valid permutations should have hours < 24 and mins < 60
            if(Convert.ToInt32(temp.Substring(0,2)) < 24 && Convert.ToInt32(temp.Substring(2,2)) < 60)
                result.Add(temp);
            return;
        }
        else {
            for(int i = 0; i < a.Length; i++) {
                temp = temp + Convert.ToString(a[i]);
                Backtrack(a, result, temp);
                temp = temp.Substring(0, temp.Length-1);
            }
        }
    }
}

// Compare strings w.r.t their int values
public class StringSorter : IComparer<string> {
    public int Compare(string x, string y) {
        return Convert.ToInt32(x) - Convert.ToInt32(y);
    }
}