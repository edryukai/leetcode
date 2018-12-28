// 108 E https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree/description/
// Sorted array to height balanced BST
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
    public TreeNode SortedArrayToBST(int[] nums) {
        if(nums == null || nums.Length == 0) return null;
        int lo = 0, hi = nums.Length-1;
        return BSTHelper(nums, 0, nums.Length-1);
    }
    
    private TreeNode BSTHelper(int[] nums, int lo, int hi) {
        if(lo > hi) return null;
        
        int mid = lo + (hi-lo)/2;
        TreeNode root = new TreeNode(nums[mid]);
        root.left = BSTHelper(nums,lo,mid-1);
        root.right = BSTHelper(nums,mid+1,hi);
        
        return root;
    }
}
