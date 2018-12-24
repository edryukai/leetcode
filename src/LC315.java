// Edge cases:
//              - Empty array
//              - Duplicates
// Logic:
//          We need count of smaller elements 'after' self. So I should have already processed the elements to the right
//          So logically we build the tree by processing from right of the array
//          We need to account for duplicates, so we will maintain a count of number of times the current element occurred
// Time:  O(nlogn) for balanced bst
// Space: O(n) for constructing tree

import java.util.*;
class Solution {
    public List<Integer> countSmaller(int[] nums) {
        List<Integer> res = new ArrayList<Integer>();
        if(nums == null || nums.length == 0) return res;
        
        TreeNode root = new TreeNode(nums[nums.length-1]);
        res.add(0);
        
        for(int i = nums.length-2; i >= 0; i--) {
            int count = insert(root, nums[i]);
            res.add(count);
        }
        
        Collections.reverse(res);
        return res;
    }
    
    public int insert(TreeNode root, int val) {
        int cnt = 0;
        while(true) {
            if(val <= root.val) {
                root.count += 1;    // increase root count coz this is one node going into left subtree
                // if we have reached the end of the path, create new node
                if(root.left == null) {
                    root.left = new TreeNode(val);
                    break;
                }
                else {
                    root = root.left;
                }
            }
            else {
                // we are going to the right so add the size of left subtree we have passed
                cnt += root.count;
                if(root.right == null) {
                    root.right = new TreeNode(val);
                    break;
                }
                else {
                    root = root.right;
                }
                
            }
        }     
        return cnt;
    }
}

class TreeNode {
    TreeNode left, right;
    int val;    // key that represents the node
    int count;  // size of to the left subtree
    
    public TreeNode(int val) {
        this.val = val;
        this.count = 1;
    }
}
