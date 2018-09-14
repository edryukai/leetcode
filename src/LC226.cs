// 226 E https://leetcode.com/problems/invert-binary-tree/description/
// Space: O(1) (ignoring stack space)
// Time: O(n)

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public TreeNode InvertTree(TreeNode root) {
        if(root == null) return null;
        
        InvertTree(root.left);
        InvertTree(root.right);
        
        TreeNode temp = root.left;
        root.left = root.right;
        root.right = temp;
        
        return root;
    }
}