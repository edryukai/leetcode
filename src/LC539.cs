// 539 M https://leetcode.com/problems/minimum-time-difference/
// Space: O(1) // considering 1440 elements as constant
// Time: O(1) // considering 1440 elements as constant

// Two solutions:
// Solution 1:
//                  - Get int values of timestamps in minutes
//                  - Sort the array of timestamps (should be O(n) sort as values will lie between 0 and 1440)
//                  - Find min distance between timestamps
//                  - Corner case: consider circular distance. Ex: 23:55 and 00:05 should give 10 minutes. 
//                  - Time: O(n), Space: O(1)
// Solution 2:
//                  - Since there are 24*60 distinct timepoints, it makes sense to have a bool array to mark those timepoints that are existent in input
//                  - Start with a small valid window, keep sliding the window to find smallest window size
//                  - Corner case: consider circular distance. Ex: 23:55 and 00:05 should give 10 minutes. 
//                  - Time: O(1), Space: O(1) since 1440 could be considered constant

/* Solution - 1 */

public class Solution {
    public int FindMinDifference(IList<string> timePoints) {
        List<int> intTimestamps = new List<int>();
        
        foreach(string x in timePoints) {
            string[] ts = x.Split(':');
            int curr = Convert.ToInt32(ts[0])*60 + Convert.ToInt32(ts[1]);
            intTimestamps.Add(curr);
        }
        
        int[] tsarray = intTimestamps.ToArray();
        Array.Sort(tsarray);
        
        int min = Int32.MaxValue;
        for(int i = 1; i < tsarray.Length; i++) {
            min = Math.Min(min, tsarray[i]-tsarray[i-1]);
        }
        
        // Corner case: checking for min distance circulary
        return Math.Min(min, tsarray[0] + (24*60 - tsarray[tsarray.Length-1]));
    }
}

/* Solution - 2 */

public class Solution {
    public int FindMinDifference(IList<string> timePoints) {
        bool[] tspoints = new bool[24*60];
        
        foreach(string x in timePoints) {
            string[] ts = x.Split(':');
            int curr = Convert.ToInt32(ts[0])*60 + Convert.ToInt32(ts[1]);
            if(tspoints[curr])  return 0;
            tspoints[curr] = true;
        }
        
        int s = 0, window_start = 0, window_end, L = 24*60 - 1, first_found_index = 0, last_found_index = 0;
        bool first_found = false;
        int min = Int32.MaxValue;
        
        // Using sliding window to compute smallest window size
        // Alternate would be to compress a window that first spans the start to end of array
        while(s <= L) {
            while(s < L && tspoints[s] != true) { s++; }
            if(s == L) break;
            window_start = s;
            if(!first_found) {
                first_found = true;
                first_found_index = s;
            }
            
            s += 1;
            while(s < L && tspoints[s] != true) { s++; }
            if(tspoints[s] == true) {
                window_end = s;
                min = Math.Min(min, window_end - window_start);
                last_found_index = window_end;
            }
        }
        
        // Corner case check: circular distance vs min. Need to track last_found_index and first_found_index
        return Math.Min(min, 1 + (L - last_found_index) + first_found_index);
    }
}