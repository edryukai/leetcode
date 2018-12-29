// 933 E 
// Numbe of valid recent calls in queue
// https://leetcode.com/problems/number-of-recent-calls/description/

public class RecentCounter {
    Queue<int> validPings;

    public RecentCounter() {
        validPings = new Queue<int>();
    }

    public int Ping(int t) {
        return MakeQueueValid(t);
    }

    private int MakeQueueValid(int t) {
        // dequeue all objects from queue which are less than t-3000
        // enqueue current ping
        // and return size of queue
        int invalid = t-3000;
        while(validPings.Count != 0 && validPings.Peek() < invalid) { validPings.Dequeue(); }
        validPings.Enqueue(t);

        return validPings.Count;
    }
}

/**
 * Your RecentCounter object will be instantiated and called as such:
 * RecentCounter obj = new RecentCounter();
 * int param_1 = obj.Ping(t);
 */
