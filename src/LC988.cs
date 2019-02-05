// 988 M https://leetcode.com/problems/smallest-string-starting-from-leaf/
// Dfs/Backtrack in tree

public class Solution {
    string smallest = "";
    string[] chars = new string[26] {"a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z"};
    
    public string SmallestFromLeaf(TreeNode root) {
        if(root == null) return string.Empty;
        Dfs(root,new StringBuilder());
        return smallest;
    }
    
    private void Dfs(TreeNode root, StringBuilder sb) {
        if(root == null) return;
        
        sb.Append(chars[root.val]);
        
        // corner case when node is leaf
        if(root.left == null && root.right == null) {
            string curr = Reverse(sb.ToString());
            if(smallest.Length == 0 || string.Compare(curr, smallest) < 0)
                smallest = curr;
        }
        
        Dfs(root.left, sb);
        Dfs(root.right,sb);
        
        // delete last char in string builder
        sb.Length--;
    }
    
    private string Reverse(string s) {
        char[] c = s.ToCharArray();
        Array.Reverse(c);
        return new string(c);
    }
}
