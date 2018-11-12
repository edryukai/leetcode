// https://leetcode.com/problems/minimum-depth-of-binary-tree/description/
// Min Depth of binary tree
// Algo: Using Level order traversal

public class Solution {
    public int MinDepth(TreeNode root) {
        if(root == null) return 0;
        
        TreeNode fi = new TreeNode(-1);
        int p = 1;
        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(root);
        q.Enqueue(fi);
        
        while(q.Count != 0) {
            TreeNode temp = q.Dequeue();
            if(temp == fi) { p++; q.Enqueue(fi); }
            else {
                if(temp.left == null && temp.right == null)
                    break;
                if(temp.left != null)
                    q.Enqueue(temp.left);
                if(temp.right != null)
                    q.Enqueue(temp.right);
            }
        }
        return p;
    }
}
