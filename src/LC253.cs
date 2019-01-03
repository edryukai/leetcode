// 253 M Meeting Rooms 2
// Find min number of conference rooms required
// Logic: sort start and end times separately
// For every start you encounter count++ and increase start_index
// For every end you encounter count-- and increase end_index

/**
 * Definition for an interval.
 * public class Interval {
 *     public int start;
 *     public int end;
 *     public Interval() { start = 0; end = 0; }
 *     public Interval(int s, int e) { start = s; end = e; }
 * }
 */
public class Solution {
    public int MinMeetingRooms(Interval[] intervals) {
        int l = intervals.Length;
        int[] s = new int[l];
        int[] e = new int[l];

        int index = 0;
        foreach(Interval x in intervals) {
            s[index] = x.start;
            e[index] = x.end;
            index++;
        }

        Array.Sort(s);
        Array.Sort(e);

        int si = 0, ei = 0, count = 0, maxCount = 0;
        while(si < l) {
            if(s[si] < e[ei]) {
                count++;
                si++;
            }
            else {
                count--;
                ei++;
            }
            maxCount = Math.Max(count, maxCount);
        }

        return maxCount;
    }
}
