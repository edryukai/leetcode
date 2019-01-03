// H 407 Trapping Rain Water in 2D plane
//     Thinking:
//      - What determines the amount of water a bar can hold?
//          > In 1D version, min of max_left_ht and max_right_ht (minus current_ht) determined it
//          > In 2D version, min of max_ht has to be found across all paths to boundary (not just 4 directions) because water can flow diagonally too
//      - In 1D approach, boundary was left and right most cells. Here boundary would be all cells along the boundary of the matrix
//      - Since we can't use two pointers given so many directions, we use a min heap and do a bfs on 4 directions. This is logically consistent because amount of water A's neighbors can hold, is for now determined by A alone
//      - Update heap as follows:
//          (i) Push all border cells into pq (max = Int32.MinValue)
//          (ii) While (pq.Count != 0)
//              - Pop smallest cell, update max if necessary (max can only go up)
//              - Visit all unvisited neighbors of the cell we just popped,
//                  > add to pq
//                  > if neighbor cell value (v) < max, then get water = (max-v)
//                  (note: neighbors => left, right, top, down)
//      - Note: Visualization (5 min): https://youtu.be/cJayBq38VYw
//

public class Solution {
  public int TrapWater2(int[,] heights) {
    if(heights == null || heights.GetLength(0) == 0 || heights.GetLength(1) == 0) return 0;

    var pq = new PriorityQueue<Cell>((a,b) -> Integer.Compare(a.ht,b.ht));

    int m = heights.GetLength(0);
    int n = heights.GetLength(1);
    bool[,] visited = new bool[m,n];

    // 1. Add all border cells into pq
    for(int i = 0; i < m; i++) {
      visited[i,0] = true;
      visited[i,n-1] = true;
      pq.offer(new Cell(i,0,heights[i,0]);
      pq.offer(new Cell(i,n-1,heights[i,n-1]);
    }

    for(int i = 0; i < n; i++) {
      visited[0,i] = true;
      visited[m-1,i] = true;
      pq.offer(new Cell(i,0,heights[0,i]);
      pq.offer(new Cell(i,n-1,heights[m-1,i]);
    }

    int max = Int32.MinValue, sum = 0;
    // 2. Pick smallest cell, visit neighbors
    int[,] dirs = new int[,] {{-1,0}, {1,0}, {0,1}, {0,-1}};
    while(pq.Count != 0) {
      Cell curr = pq.poll();
      max = Math.Max(curr.ht, max);
      if(curr.ht < max) {
        sum += max - curr.ht;
      }

      for(int[] dir in dirs) {
        int row = cell.row + dir[0];
        int col = cell.col + dir[1];

        if(row >= 0 && row < m && col >= 0 && col < n && !visited[row,col]) {
          visited[row,col] = true;
          pq.offer(new Cell(row, col, heights[row,col]));
        }
      }
    }

    return sum;
  }
}

public class Cell {
  int row, col, ht;
  public Cell(int r, int c, int h) {
    row = r;
    col = c;
    ht = h;
  }
}
