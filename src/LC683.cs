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