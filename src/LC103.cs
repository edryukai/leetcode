// 103 M Zig Zag level order traversal
// https://leetcode.com/problems/binary-tree-zigzag-level-order-traversal/description/

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
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
        IList<IList<int>> res = new List<IList<int>>();
        if(root == null) return res;

        var tempList = new List<int>();
        TreeNode fi = new TreeNode(Int32.MinValue);
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        q.Enqueue(fi);
        int levelCount = 0;

        while(q.Count != 0) {
            TreeNode temp = q.Dequeue();
            // end of level
            if(temp == fi) {
                if(++levelCount % 2 == 0) {
                    tempList.Reverse();
                    res.Add(tempList);
                }
                else
                    res.Add(tempList);

                tempList = new List<int>();
                if(q.Count == 0) break;
                else q.Enqueue(fi);
            }
            else {
                tempList.Add(temp.val);
                if(temp.left != null) q.Enqueue(temp.left);
                if(temp.right != null) q.Enqueue(temp.right);
            }
        }
        return res;
    }
}
