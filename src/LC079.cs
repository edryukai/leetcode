// 079 M https://leetcode.com/problems/word-search/description/
// Plain old DFS
// Space: O(1) (discounting stack space)
// Time: O(rc)

public class Solution {
    public bool Exist(char[,] board, string word) {
        if (word == null || word.Length == 0)   return true;
        char[] chars = word.ToCharArray();
        
        for(int i = 0; i < board.GetLength(0); i++) {
            for(int j = 0; j < board.GetLength(1); j++) {
                if(DFS(board, chars, 0, i, j)) {
                    return true;
                }
            }
        }
        return false;
    }
    
    // curr_index => current index in the word we're at
    // x,y => coordinates we're at in the board
    public bool DFS(char[,] board, char[] chars, int curr_index, int x, int y) {
        /*
        *   Exit conditions:
        *           1. Covered entire board but couldn't find the word
        *           2. Index out of bounds of grid
        *           3. Word can't be included in path
        */
        
        if(curr_index == chars.Length) { return true; }
        if(x < 0 || x == board.GetLength(0) || y < 0 || y == board.GetLength(1)) { return false; }
        if(board[x,y] != chars[curr_index]) { return false; }
        
        // mask current node
        board[x,y] ^= Convert.ToChar('2');
        
        // explore neighbors
        bool res = DFS(board, chars, curr_index + 1, x, y+1)
                    || DFS(board, chars, curr_index + 1, x, y-1)
                    || DFS(board, chars, curr_index + 1, x+1, y)
                    || DFS(board, chars, curr_index + 1, x-1, y);
        
        // restore current node
        board[x,y] ^= Convert.ToChar('2');
        
        return res;
    }
}