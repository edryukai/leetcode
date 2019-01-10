// https://leetcode.com/problems/maximize-distance-to-closest-person/description/
// Maximise distance to closest person
// Time: O(n) 
// Space: O(1)

public class Solution {
    public int MaxDistToClosest(int[] seats) {
        // could be at beginning or end
        int maxDist = 0;
        int start = 0, end = seats.Length-1;
        
        // 1. scan from beginning
        for(int i = 0; i < seats.Length; i++) {
            if(seats[i] == 1) { start = i; break; }
            maxDist = Math.Max(maxDist, i+1);
        }
        
        // 2. scan from end
        for(int i = seats.Length-1; i >= 0; i--) {
            if(seats[i] == 1) { end = i; break; }
            maxDist = Math.Max(maxDist, seats.Length-i);
        }
        
        // or in middle of two people
        // in which case find the longest set of 0s and divide by 2.
        int localDist = 0;
        for(int i = start; i <= end; i++) {
            // increase count if empty seat
            if(seats[i] == 0) localDist++;
            // encountered a person. Update max as per dist/2 since it means we are sitting in middle
            // update localDist to 0
            // note: doing (1+localDist) because localDist gives number of 0s, but we need to add 1 to find closest dist
            // refer given example to understand what i am saying
            else {
                maxDist = Math.Max(maxDist, (1+localDist)/2);
                localDist = 0;
            }
        }
        
        return maxDist;
    }
}