// Search in a 2D matrix sorted row wise and col wise

/*
	Logic:

	Notice the first row and last column.. i.e continue the values 1,4,7,11,15 to column
	1,4,7,11,15,19,22,24,30! - the whole thing is sorted

	So if we consider top right corner as our starting position, it's almost like staying in the middle of the whole continued row. We can easily narrow our search to one of the halves.
	i.e

	Initialize current position to top right corner (call it curr_trc).
	If target is > curr_trc then it should lie in the column (and we can eliminate the row)
	If target is < curr_trc then it should lie in the row (and we can eliminate the column)

	Thus we rule out one row and one column each time. So solution is O(m+n)
*/

public class Solution {
    public bool SearchMatrix(int[,] matrix, int target) {
        int r = matrix.GetLength(0);
    		int c = matrix.GetLength(1);

		    if(matrix == null || r == 0 || c == 0)
			    return false;

		    // initialize starting position
		    int row = 0, col = c-1;

		    while(col >= 0 && row < r) {
			    if(target == matrix[row,col])
				    return true;
			    else if(target < matrix[row,col])		// eliminate column
				    col--;
			    else                                	// eliminate row
				    row++;
		    }

		    return false;
    }
}
