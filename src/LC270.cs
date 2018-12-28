// 270 E Closest value for a given val in BST
// https://leetcode.com/problems/closest-binary-search-tree-value/description/
// Follow up: https://leetcode.com/problems/closest-binary-search-tree-value-ii/description/

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
    public int ClosestValue(TreeNode root, double target) {
        if(root == null) return -1;
        
        int res = root.val;
        double dif = Math.Abs(target - (double)root.val);
        
        while(root != null) {
            if(Math.Abs(target - (double)root.val) < dif) {
                dif = Math.Abs(target - (double)root.val);
                res = root.val;
            }
            
            if(root.val > target)
                root = root.left;
            else
                root = root.right;
        }
        
        return res;
    }
}
