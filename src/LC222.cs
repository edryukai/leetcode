// 222 M Count nodes in a complete binary tree
// Nice question
// https://leetcode.com/problems/count-complete-tree-nodes/description/

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
    public int CountNodes(TreeNode root) {
        // except last level, all levels are filled
        // at every point, check the heights of left and right subtrees
        // 1. if height of right subtree is 1 less than height of root, it means last node on last level is in the right subtree
        //      so we add 2^h-1 nodes from the left subtree to our result (plus the current node )and dive down into right subtree
        // 2. if height of right subtree is more than 1 less than height of root, it means the last node on last level is in
        //      left subtree, so we add the 2^(h-1)-1 nodes that are a part of our right subtree (plus current node)
        //      into our result and dive down further left
        // At every level, we are computing height. So it's O(log n)^2

        int nodes = 0, h = height(root);

        while(root != null) {
            if(height(root.right) == h-1) {
                nodes += 1 << h;
                root = root.right;
            }
            else {
                nodes += 1 << (h-1);
                root = root.left;
            }
            h--;
        }
        return nodes;
    }

    private int height(TreeNode root) {
        if(root == null)
            return -1;
        return 1 + height(root.left);
    }
}
