// 539 M https://leetcode.com/problems/minimum-time-difference/
// Space: O(1) // considering 1440 elements as constant
// Time: O(1) // considering 1440 elements as constant

// Logic:
// - Since there are 24*60 distinct timepoints, it makes sense to have a bool array to mark those timepoints that are existent in input
// - Corner case:  23:59 and 00:03 should give 4 minutes instead of 1436 - i.e consider circularly
//                 To deal with this, if I keep track of the first and last window indices that were found, I can check for 'circular' kind of distance to compare with min computed so far 

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