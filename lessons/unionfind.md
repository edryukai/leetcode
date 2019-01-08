## [947](https://leetcode.com/problems/most-stones-removed-with-same-row-or-column/description/) Most stones removed with same row or column
* Number of stones removed = number of stones in input - number of islands
* Simple union find

## [305](https://leetcode.com/problems/number-of-islands-ii/solution/) Number of islands 2
* Number of islands is straight forward union find
* In this qn, land is added in each operation and you need to find number of islands at every step
* **Logic**:
  * For each `addLand` operation, union it with it's adjacent 4 way neighbors
  * If all of it's neighbors are water, then just initialize this as a new island

## [803](https://leetcode.com/problems/bricks-falling-when-hit/description/) Bricks Falling When hit
* Solve this in reverse. i.e proceed from last hit, and consider that as adding a brick. Now it becomes similar to number of islands 2.
  * Instead of finding number of components, you need to find the size of the component attached to the roof (first row)
* To maintain the roof, let's introduce one more pseudo-vertex, call that the source and connect our roof to the source pseudo-vertex
  * The way to do this in code is to initialize UF with size `m*n+1` and make the last element as source
* Another condition to check is that if a hit is happening at `[r,c]` and in the input matrix the element there is `0`, then we don't do anything. This is because it means there was no brick there to begin with.

## [130](https://leetcode.com/problems/surrounded-regions/discuss/41617/Solve-it-using-Union-Find) Surrounded Regions
* Simple logic again: nodes on boundary can't be captured and nodes connected to those on the boundary can't be captured
* Make a dummy node, init your array to `m*n+1` and then connect all boundary nodes to that node
* **Learning**: If you want to maintain specific properties w.r.t nodes on boundary/roof etc, make a dummy node

## [128](https://leetcode.com/problems/longest-consecutive-sequence/description/) Length of longest consecutive sequence in O(n)
* Union find + dictionary
* Scan every element, and add to dictionary
* While scanning, check if dict contains `currNum-1` and `currNum+1` also in keys, and if so, union them
* Return size of largest connected component

## [765](https://leetcode.com/problems/couples-holding-hands/solution/) Couples holding hands
* `(0,1) (2,3)` ... are partners. Given `x`, `partner = x^1`
* **Greedy**: fix first partner and do swaps to get their right partner in place. If you maintain hashmap of positions, then it can be done in `O(n)` time and `O(n)` space
* **UnionFind**: 
  * Assume a single couch to hold two partners. Essentially we need N couches in case of N couples
  * Construct a graph between couches such that there is an undirected edge from every guy to their partner. Note that all vertices have even degree
  * This graph will have some sort of a cycle that gives total number of connected components. If each couple has their own couch, then `#connected components = N`
  * So we need to just return `N - #currently_connected_components`

## [685](https://leetcode.com/problems/redundant-connection-ii/description/) Redundant Connection 2
* For this problem, we have a directed graph instead of an undirected graph
* Every node except the root has exactly one parent, remove faulty node
* The structure is invalid under two conditions:
  1. A node has two parents
  2. Cycle exists
* So first process all edges and see if a node has two parents. Call them `candidate_a, candidate_b` and set the second edge as invalid
* Perform normal union find
  * If the tree is now valid, return `candidate_b`
  * If no candidates exist, then we get a cycle, return the edge causing it
  * Else return `candidate_a`
