// 295 H Median of stream
// Explanation in lessons/heap.md

import java.util.*;

class MedianFinder {
    // lo => max heap, hi => min heap
    Queue<Long> lo,hi;
    
    public MedianFinder() {
        lo = new PriorityQueue<>();
        hi = new PriorityQueue<>();
    }
    
    public void addNum(int num) {
        hi.offer((long)num);
        lo.offer(-hi.poll());
        if(hi.size() < lo.size()) {
            hi.offer(-lo.poll());
        }
    }
    
    public double findMedian() {
        return hi.size() > lo.size() ? hi.peek() : (hi.peek() - lo.peek())/2.0;
    }
}

/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.addNum(num);
 * double param_2 = obj.findMedian();
 */
