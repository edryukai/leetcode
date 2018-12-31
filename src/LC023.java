// 23 - H - https://leetcode.com/problems/merge-k-sorted-lists/description/
// Space: O(k) for the heap
// Time: O(n log k) where n is total number of nodes because there's a log k time for every insertion/retrieval

import java.util.*;
class ListNode {
      int val;
      ListNode next;
      ListNode(int x) { val = x; }
}

class Solution {
    public ListNode mergeKLists(ListNode[] lists) {
        if(lists == null || lists.length == 0)
            return null;
        
        PriorityQueue<ListNode> pq = new PriorityQueue<ListNode>(lists.length, new Comparator<ListNode>() {
            public int compare(ListNode n1, ListNode n2) {
                return n1.val - n2.val;
            }
        });
        
        // populate pq first with heads of all lists in input
        for(ListNode n : lists) {
            if(n != null)
                pq.add(n);
        }
        
        ListNode dummy = new ListNode(0);
        ListNode tail = dummy;
        
        while(!pq.isEmpty()) {
            // update tail to point to latest head and advance it
            tail.next = pq.poll();
            tail = tail.next;
            
            // if there is an element in the list whose head we processed
            // add that to the pq
            if(tail.next != null)
                pq.add(tail.next);
        }
        
        return dummy.next;
    }
}
