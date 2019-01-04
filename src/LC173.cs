// Problem: https://leetcode.com/problems/binary-search-tree-iterator/description/ 
// Tags: Stack
// Level: M
// Problem Number: 173 
// Solution Link: 
// Relevant Links: https://discuss.leetcode.com/topic/6575/my-solutions-in-3-languages-with-stack, https://leetcode.com/problems/binary-search-tree-iterator/discuss/

/**
 * Definition for binary tree
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

 /*
        BST iterator is basically saying "get next element in in-order fashion"
        While this can be done using an array, it takes up O(n) memory, where was we want O(h) memory - this itself gives a hint of a root to leaf path
        
        To get smallest tree node, we need to go to left most TreeNode. But the problem is backtracing its parent. Which means we need to store its father before-hand.
        This requirement is satisifed when you store all nodes in root to leaf path in stack.

        Now let's say we exhausted left branch and our node currently only has right branch. In that case we need to go to left most child in that right branch.
        HasNext() => O(1), Next() => O(h)
 */

public class BSTIterator {
    private Stack<TreeNode> stack = new Stack<TreeNode>();

    public BSTIterator(TreeNode root) {
        PushAll(root);
    }

    /** @return whether we have a next smallest number */
    public bool HasNext() {
        return !(stack.Count == 0);
    }

    /** @return the next smallest number */
    public int Next() {
        TreeNode temp = stack.Pop();
        PushAll(temp.right);

        return temp.val;
    }

    private void PushAll(TreeNode node) {
        while (node != null) {
            stack.Push(node);
            node = node.left;
        }
    }
}

/**
 * Your BSTIterator will be called like this:
 * BSTIterator i = new BSTIterator(root);
 * while (i.HasNext()) v[f()] = i.Next();
 */
