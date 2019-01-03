// 378 M https://leetcode.com/problems/kth-smallest-element-in-a-sorted-matrix/description/
// K-th smallest element in sorted matrix:
//     - Note: sorted matrix, so there is an order to the numbers
//     - Build a heap with all elements from first row
//     - When you getMin(), note which row and col the element came from
//     - Add next unprocessed element from that col in heap 

public class Solution {
    public int kthSmallest(int[][] matrix, int k) {
        int l = matrix.length;
        PriorityQueue<Tuple> pq = new PriorityQueue<Tuple>();
        
        for(int i = 0; i < n; i++) {
            pq.offer(new Tuple(0,j,matrix[0][j]));
        }

        for(int i = 0; i < k-1; i++) {
            Tuple t = pq.poll();
            if(t.x == n-1) continue;    // no more elements to add
            pq.offer(new Tuple(t.x+1, t.y, matrix[t.x+1][t.y]));
        }
        return pq.poll().val;
    }
}

class Tuple implements Comparable<Tuple> {
    int x, y, val;
    public Tuple(int x, int y, int val) {
        this.x = x;
        this.y = y;
        this.val = val;
    }

    public int compareTo(Tuple that) {
        return this.val - that.val;
    }
}
