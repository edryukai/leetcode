## [378] K-th smallest element in sorted square matrix
* Note: sorted square matrix, so there is an order to the numbers and r == c 
* Build a heap with all elements from first row
* When you getMin(), note which row and col the element came from
* Add next unprocessed element from that col in heap 
* Alternatively, you can use BinarySearch with a slight modification
* https://leetcode.com/problems/kth-smallest-element-in-a-sorted-matrix/discuss/85173/Share-my-thoughts-and-Clean-Java-Code

## [373] Find k pairs with smallest sums
* Lets call input arrays nums1 and nums2. Lengths l1 and l2
* Note: Key observation is that all resultant pairs must be within first k elements in nums1 and first k elements in nums2 
* First take k elements of nums1 and pair it with nums2[0] as starting point. So we have indices wise (0,0) (1,0) ... (k-1,0) in heap 
* Each time we pick pair with min sum, put the new pair with index (ind1, 1+ind2) [i.e if we get (0,0), we put back (1,0)]
* return when k elements have been processed

* **Lessons learned here**:
    * k-th largest/smallest => usually tend towards heaps
    * Heapify for the condition (ex: in 373, heapify for min sum. In 378, heapify for min number)

## [787] Cheapest flights within K stops
* We start with src in pq and maintain an object "Destination" that holds current price, #stops remaining etc.
* We explore all possible hubs from src, greedily (with least price first)
* If we hit our target dest, we return the price there 
* Else in a DFS-y fashion, we put all possible hubs from the hub we get through pq.poll() back in pq with updated prices and num of remaining stops
* If for a hub, num of `remaining_stops <= 0`, it means we haven't reached dest and can't go ahead, so we just ignore

## [042] Trapping Rain Water 1
* Amount of water trapped above each block is determined by `Min(max_ht_to_left, max_ht_to_rt) - current_ht`
* Naive way of doing: maintain two arrays for `max_left`, `max_right` and do the above computation, but it takes O(n) space
* Efficient way: maintain two pointers left and right, two heights leftMax and rightMax and update contributions and leftMax and rightMax accordingly

## [407] Trapping Rain Water 2
* What determines the amount of water a bar can hold?
    * In 1D version, min of `max_left_ht` and `max_right_ht` (minus `current_ht`) determined it 
    * In 2D version, min of `max_ht` has to be found across all paths to boundary (not just 4 directions) because water can flow diagonally too 
* In 1D approach, boundary was left and right most cells. Here boundary would be all cells along the boundary of the matrix
* Since we can't use two pointers given so many directions, we use a min heap and do a bfs on 4 directions. This is logically consistent because amount of water A's neighbors can hold, is for now determined by A alone 
* Update heap as follows:
    * Push all border cells into pq (max = Int32.MinValue)
    * While (pq.Count != 0)
        * Pop smallest cell, update max if necessary (max can only go up)
        * Visit all unvisited neighbors of the cell we just popped, 
            * add to pq
            * if neighbor cell value (v) < max, then get water = (max-v) 
            * (note: neighbors => left, right, top, down)
* Note: Visualization (5 min): https://youtu.be/cJayBq38VYw

## [659] Split array into consecutive subsequences 
* Think of subsequences as intervals. You need to find the right interval for a current number 
* The right interval would be the one with the largest "end" so far, since we have array in a sorted fashion
* In case of tie break, one with shorter length will be returned

## [857] Min Wage for K Workers
* `final_wage[i]/qual[i] = final_wage[j]/qual[j]`
    *and there will be at least one guy in a group whose `final_wage` will be same as `min_wage`
    *let's call that guy `captain` and ratio as `final_wage[capt]/qual[capt]` which is same as `min_wage[capt]/qual[capt]`
* In a group of K people,
    * capt determines the ratio.
    * From the equation in first step, `final_wage[x] = ratio[capt] * qual[x]`
    * So if we fix the capt, we fix a ratio and we can get final_wage of everyone in the group
* Naively, this can be done greedily by fixing ratio and trying out all workers to see which k workers are best
* Optimally, we note a few things:
    * `total_wage = ratio * qual[1] + ratio * qual[2] + ... + ratio * qual[k]`
    * which is same as `total_wage = ratio * sum(quality_of_group)`
    * To minimize `total_wage`, we need a small `ratio`. **So we iterate over ratios and pick an optimal group**
    * So we first calculate ratio of all workers, and sort them by ratio. Let's pick the first K workers now
    * So `total_wage` now is `ratio[k-1]*sum(quality[0..k-1])`
    * When we consider the next guy for our group of size k, we get guy with next higher ratio. This means ratio for entire group increased.
    * Who do we out? The guy in our group with **highest quality**. Coz higher quality increases total wage
        * Think about it. Pick some random guy in the group. This guy has some wage and some quality
        * But the ratio is fixed, so his wage doesn't matter. So the only factor that affects our total sum is quality
        * total_wage is directly proportional to quality so we kick the guy with max quality off the group
    * tldr: for a given ratio of wage/quality, find minimum total_wage of k workers
* FAQ: When we remove the worker with highest quality, it could as well be our new worker. Then we would be using his ratio, while he is not there.
    * This case doesn't matter because, we will then be left with the same group as before, and we already calculate `total_wage` for that group with a lower ratio (since we are picking people based on sorted ratios, remember?)

