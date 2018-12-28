// 426 M BST to DLL
// https://leetcode.com/problems/convert-binary-search-tree-to-sorted-doubly-linked-list/description/
/*
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;

    public Node(){}
    public Node(int _val,Node _left,Node _right) {
        val = _val;
        left = _left;
        right = _right;
}
*/
public class Solution {
    public Node prev = null;
    
    public Node TreeToDoublyList(Node root) {
        if(root == null) return null;
        
        Node dummy = new Node(-1,null,null);
        prev = dummy;
        
        // connect tree
        Helper(root);
        
        // make it circular
        prev.right = dummy.right;   // connecting tail to head
        dummy.right.left = prev;    // connecting head to tail
        return dummy.right;
    }
    
    public Node Helper(Node curr) {
        if(curr == null) return null;
        // in-order fashion connect tree
        Helper(curr.left);
        
        prev.right = curr;
        curr.left = prev;
        prev = curr;
        
        Helper(curr.right);
        return curr;
    }
}
