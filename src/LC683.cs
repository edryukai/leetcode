// Elegant af Java solution first using BST, then an alternate straight forward C# solution
// O(n log n)
// Using BST
// For every element, check immediate lowest and immediate highest
// If the difference in either is k+1, it means no flowers bloomed !
// Else add to bst and continue !

class Solution {
    public int kEmptySlots(int[] flowers, int k) {
        TreeSet<Integer> bst = new TreeSet<>();
        
        for(int i = 0; i < flowers.length; i++) {
            int current = flowers[i];
            
            // lower: Returns the greatest element strictly less than the given element, or null if there is no such element
            Integer prev = bst.lower(current);
            if(prev != null && current - prev == k+1)
                return i+1;
           
            // higher: Returns the least element strictly greater than the given element, or null if there is no such element.
            Integer next = bst.higher(current);
            if(next != null && next - current == k+1)
                return i+1;
            
            bst.add(current);
        }
        
        return -1;
    }
}

// ALITER: Moving window
// O(n)
// Logic:
//  Let days[i] represent the day flower in position i+1 blooms
//  A window [left,right] is a valid window if:
//      (i) there are k elements between them (not inclusive)
//      (ii) for every element between left and right,  days[i] > days[left] and days[i] > days[right]
//              i.e all the elements between left and right bloomed *after* left and right did
// So we start that window of size k+1 at left = 0, right = k+1 (such that there are k elements in middle)
// Whenever we encounter anomaly, we start a new window there

public int kEmptySlots(int[] flowers, int k) {
    int[] days =  new int[flowers.length];
    for(int i=0; i<flowers.length; i++)days[flowers[i] - 1] = i + 1;
    int left = 0, right = k + 1, res = Integer.MAX_VALUE;
    for(int i = 0; right < days.length; i++){
        if(days[i] < days[left] || days[i] <= days[right]){
            if(i == right)res = Math.min(res, Math.max(days[left], days[right]));   //we get a valid subarray, and whatever day is max, that's the result
            // otherwise start new window at index i
            left = i; 
            right = k + 1 + i;
        }
    }
    return (res == Integer.MAX_VALUE)?-1:res;
}

// ALITER:
// https://leetcode.com/problems/k-empty-slots/description/
// 683 H K empty slots in garden

// Process flowers one by one
// Every time, check if the flower k positions away to the left and to the right has bloomed.
//      If so, verify that the ones in the middle aren't bloomed

// Space: O(n)
// Time: Actually looks like O(nk) in the worst case because you have to scan k elements to the left and right for each element
//       But if you think carefully, if you have processed i elements, then you have also bloomed i elements so you're not really searching for k all the time. 
// ToDo: Need to work on exact worst case time.

public class Solution {
    public int KEmptySlots(int[] flowers, int k) {
        
        int fl = flowers.Length;
        bool[] bloom = new bool[fl];
        
        for(int i = 0; i < fl; i++) {
            int index = flowers[i]-1;
            bloom[index] = true;
            int left = index-k-1;
            int right = index+k+1;
            bool foundLeft = false, foundRight = false;
            bool processedLeft = false, processedRight = false;
            
            // we have a left bloom with distance k
            if(left >= 0 && bloom[left]) {
                // verify that no others to the left bloomed 
                int j = index-1;
                foundLeft = false;
                processedLeft = true;
                
                while(j > left && !foundLeft) {
                    if(bloom[j--]) {
                        foundLeft = true;
                    }
                }
            }
            
            // Note: need to maintain processedLeft to make sure that we have valid entries to the left that we checked
            // As an edge case, for element with index 1, we will never process left side and foundLeft will also be false
            // which is a false positive
            // Similar logic can be argued for processedRight
            if(processedLeft && !foundLeft)
                return i+1;
            
            // we have a right bloom with distance k
            if(right <= fl-1 && bloom[right]) {
                // verify that no others to the right bloomed
                int j = index+1;
                foundRight = false;
                processedRight = true;
                
                while(j < right && !foundRight) {
                    if(bloom[j++]) {
                        foundRight = true;
                    }
                }
            }
            
            if(processedRight && !foundRight)
                return i+1;
        }
        
        return -1;
    }
}