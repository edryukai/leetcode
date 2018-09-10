// https://leetcode.com/problems/number-of-islands/description/
// Given a 2d grid map of '1's (land) and '0's (water), count the number of islands. An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. You may assume all four edges of the grid are all surrounded by water.

// 2D to 1D array =>
//      arr[m,n] maps to m * col + n

// Space complexity:    O(r*c) for representatives in union find
// Time complexity:
//                      If m operations, either Union or Find, are applied to n elements, the total run time is O(m log*n), where log* is the iterated logarithm.
//                      For all practical values, value of log* <= 5 so can be considered constant. Hence m operations on n elements can be considered O(m)
//          # operations = O(r*c) so complexity = O(r*c)

public class Solution {
    public int NumIslands(char[,] grid) {
        int row = grid.GetLength(0),
            col = grid.GetLength(1);

        UnionFind uf = new UnionFind(grid, row, col);

        int p = 0;
        for(int i = 0; i < row; i++) {
            for(int j = 0; j < col; j++) {
                p = i * col + j;

                if(grid[i,j] == '1') {
                    // up => grid[i-1,j]
                    if(i-1 >= 0 && grid[i-1,j] == '1')
                        uf.Union(p, p-col);
                    // down => grid[i+1,j]
                    if(i+1 <= row-1 && grid[i+1,j] == '1')
                        uf.Union(p, p+col);
                    // left => grid[i,j-1]
                    if(j-1 >= 0 && grid[i,j-1] == '1')
                        uf.Union(p, p-1);
                    // right => grid[i,j+1]
                    if(j+1 <= col-1 && grid[i,j+1] == '1')
                        uf.Union(p, p+1);
                }
            }
        }
        return uf.NumberOfComponents();
    }
}

public class UnionFind {
    int[] id;
    int count;

    public UnionFind(char[,] grid, int m, int n) {
        id = new int[m*n];
        // consider all 1s are independent islands initially
        for(int i = 0; i < m; i++) {
            for(int j = 0; j < n; j++) {
                if(grid[i,j] == '1')
                    count++;
            }
        }
        // Initialize union find representatives
        for(int i = 0; i < m*n; i++)
            id[i] = i;
    }

    private int Root(int i) {
        while(i != id[i]) {
            id[i] = id[id[i]];
            i = id[i];
        }
        return i;
    }

    public bool AreConnected(int p, int q) {
        return Root(p) == Root(q);
    }

    public void Union(int p, int q) {
        int pRoot = Root(p), qRoot = Root(q);
        if(pRoot != qRoot) {
            id[pRoot] = qRoot;
            count--;
        }
    }

    public int NumberOfComponents() {
        return count;
    }
}