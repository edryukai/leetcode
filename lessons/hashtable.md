## [463] Islands Perimeter [link](https://leetcode.com/problems/island-perimeter/description/)
* Loop over the matrix and count the number of individual islands (aka where `grid[i,j] == 1`)
* If the current dot is an island, count if it has any **right neighbour or down neighbour**
* The result is islands * 4 - neighbours * 2
    * Because, every island contributes 4 edges
    * If you count the neighbor too, then you are adding 2 edges
    * You only consider neighbors in one direction across each axis (aka right and down)
    * Coz otherwise you will count duplicates (x is a neighbor of y, then when you count for y you end up counting x again)

## [560] Number of subarrays that sum to K [link](https://leetcode.com/problems/subarray-sum-equals-k/description/)
* Similar to finding if there's a subarray that sums to K
* Maintain prefix sums in dictionary, and count of number of times that prefixSum has occurred (coz there could be -ve elements)
* If dict contains `prefixSum - k`, it means we have a window that adds to `k`
* Just keep maintining count
* Imp edge case: `d[0] = 1` (coz empty array means sum == 0)

## [939](https://leetcode.com/problems/minimum-area-rectangle/) Minimum area of rectangle by points in a plane
* Consider every pair of points as a diagonal to the rectangle `(x1,y1) (x2,y2)`
* For this pair we need to check if the other corresponding points of the rectange exist i,e `(x1,y2), (x2,y1)`
* If they do, we update the area and move on till we exhaust all pairs
* Time: `O(n^2)` Space: `O(n)`

## [299](https://github.com/edryukai/leetcode/blob/master/src/LC299.cs) Bulls and Cows
* Idea is to scan bulls and cows simultaneously while increasing or decreasing count[] array
* Check the solution for better detail