// * Loop over the matrix and count the number of individual islands (aka where `grid[i,j] == 1`)
// * If the current dot is an island, count if it has any **right neighbour or down neighbour**
// * The result is islands * 4 - neighbours * 2
//     * Because, every island contributes 4 edges
//     * If you count the neighbor too, then you are adding 2 edges
//     * You only consider neighbors in one direction across each axis (aka right and down)
//     * Coz otherwise you will count duplicates (x is a neighbor of y, then when you count for y you end up counting x again)

public class Solution {
    public int islandPerimeter(int[][] grid) {
        int islands = 0, neighbours = 0;

        for (int i = 0; i < grid.length; i++) {
            for (int j = 0; j < grid[i].length; j++) {
                if (grid[i][j] == 1) {
                    islands++; // count islands
                    if (i < grid.length - 1 && grid[i + 1][j] == 1) neighbours++; // count down neighbours
                    if (j < grid[i].length - 1 && grid[i][j + 1] == 1) neighbours++; // count right neighbours
                }
            }
        }

        return islands * 4 - neighbours * 2;
    }
}
