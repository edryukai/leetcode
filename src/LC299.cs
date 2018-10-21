// 299 https://leetcode.com/problems/bulls-and-cows/description/
// Bulls and Cows
public class Solution {
    public string GetHint(string secret, string guess) {
        var secret_d = new Dictionary<char,HashSet<int>>();
        var guess_d = new Dictionary<char,HashSet<int>>();
        
        // Caputre counts for secret and guess. Also need to capture positions
        for(int i = 0; i < secret.Length; i++) {
            char secret_key = secret[i];
            char guess_key = guess[i];
            
            if(secret_d.ContainsKey(secret_key))
                secret_d[secret_key].Add(i);
            else
                secret_d[secret_key] = new HashSet<int>(){i};
            
            if(guess_d.ContainsKey(guess_key))
                guess_d[guess_key].Add(i);
            else
                guess_d[guess_key] = new HashSet<int>(){i};
        }
        
        int bulls = 0, cows = 0;

        // Validate all guesses & positions
        // Logically, let's say an element 'x' occurs at positions {0,1} in secret and {1,2,3} in guess
        //      We have one match/bull which is easy to count
        //      The number of position mismtach/cows is essentially min of secret_val and guess_val minus the matches we already saw in those
        //          The min part becomes clear when you think about secret having {0,1,2} and guess having {1,3}
        foreach(var kvp in guess_d) {
            if(secret_d.ContainsKey(kvp.Key)) {
                var secret_val = secret_d[kvp.Key];
                var guess_val = guess_d[kvp.Key];
                
                int count = 0;
                foreach(int x in guess_val) {
                    if(secret_val.Contains(x))
                        count++;
                }
                
                bulls += count;
                cows += Math.Max(0, Math.Min(secret_val.Count-count, guess_val.Count-count));
            }
        }
        
        return string.Format("{0}A{1}B",bulls,cows);
    }
}

/* Aliter One pass O(n) time solution

    Idea: iterate over numbers in secret and guess and count all bulls right off the bat
    For cows, maintain an array that stores #of appearances in secret and guess. Increment cows when either number from secret
        was already seen in guest, or vice versa
 */

 public class Solution {
    public string GetHint(string secret, string guess) {
        int bulls = 0, cows = 0;
        int[] count = new int[10];

        for(int i = 0; i < secret.Length; i++) {
            int s = secret[i]-'0';
            int g = guess[i]-'0';

            if(s == g) bulls++;
            else {
                if(count[s] < 0) cows++;
                if(count[g] > 0) cows++;
                count[s]++;
                count[g]--;
            }
        }
        return string.Format("{0}A{1}B",bulls,cows);
    }
}