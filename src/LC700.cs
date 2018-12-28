// 700 E https://leetcode.com/problems/search-in-a-binary-search-tree/description/
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
    public TreeNode SearchBST(TreeNode root, int val) {
        if(root == null) return null;
        if(root.val == val) return root;
        TreeNode r = SearchBST(root.right, val);
        TreeNode l = SearchBST(root.left, val);
        return r ?? l ?? null;
    }
}
