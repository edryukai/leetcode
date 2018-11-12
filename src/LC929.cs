// https://leetcode.com/problems/unique-email-addresses/description/
// Unique Email Addresses

// Straightforward algo
// Process domain names separately, local names as per rules

public class Solution {
    public int NumUniqueEmails(string[] emails) {
        HashSet<string> h = new HashSet<string>();
        foreach(string email in emails) {
            h.Add(ProcessMail(email));
        }
        return h.Count;
    }
    
    private string ProcessMail(string email) {
        string[] s = email.Split('@');
        return ProcessLocal(s[0]) + "@" + s[1];
    }
    
    private string ProcessLocal(string local) {
        StringBuilder sb = new StringBuilder();
        foreach(char c in local.ToCharArray()) {
            if(c == '+') { break; }
            if(c == '.') { continue; }
            sb.Append(c.ToString());
        }
        return sb.ToString();
    }
}

// Aliter: Simpler

// https://leetcode.com/problems/unique-email-addresses/description/
// Unique Email Addresses

// Straightforward algo
// Process domain names separately, local names as per rules
public class Solution {
    public int NumUniqueEmails(string[] emails) {
        HashSet<string> h = new HashSet<string>();
        foreach(string email in emails) {
            string[] parts = email.Split('@');
            string[] locals = parts[0].Split('+');
            h.Add(locals[0].Replace(".", "") + "@" + parts[1]);
        }
        return h.Count;
    }
}
