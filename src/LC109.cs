// 109 M https://leetcode.com/problems/convert-sorted-list-to-binary-search-tree/description/
// Convert sorted LL to BST

public class Solution {
    public TreeNode SortedListToBST(ListNode head) {
      if(head == null) return null;
      return BSTHelper(head, null);
    }

    public TreeNode BSTHelper(ListNode head, ListNode tail) {
      if(head == tail) return null;
      
      ListNode slow = head, fast = head;
      // find mid
      while(fast != tail && fast.next != tail) {
        fast = fast.next.next;
        slow = slow.next;
      }

      TreeNode root = new TreeNode(slow.val);
      root.left = BSTHelper(head, slow);
      root.right = BSTHelper(slow.next, tail);

      return root;
    }
}
