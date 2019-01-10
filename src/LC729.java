// https://leetcode.com/problems/my-calendar-i/description/
// lesson: Use BST when you are dealing with ranges of values that you need to search for, for insertion etc.
// like finding the right insertion point in the intervals

class MyCalendar {
    TreeMap<Integer, Integer> map;
    
    public MyCalendar() {
        map = new TreeMap<>();       
    }
    
    public boolean book(int start, int end) {
        Integer low = map.lowerKey(end);

        if(low == null || map.get(low) <= start) {
            map.put(start, end);
            return true;
        }
        return false;
    }
}

/**
 * Your MyCalendar object will be instantiated and called as such:
 * MyCalendar obj = new MyCalendar();
 * boolean param_1 = obj.book(start,end);
 */