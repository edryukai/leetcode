// E 346 Moving average from data stream
// https://leetcode.com/problems/moving-average-from-data-stream/description/

public class MovingAverage {

    public int k, sum;
    public Queue<int> q;
    public double avg;

    // We maintain sum and average separately to avoid loss in case of recurring decimals
    public MovingAverage(int size) {
        k = size;
        q = new Queue<int>();
        avg = 0.0;
        sum = 0;
    }

    // when first element goes out of queue and new element enters queue
    // to get new average,
    // 1. multiply current average with queue size to get sum 'S'
    // 2. if queue size == window size only then dequeueing happens
    // 3. depending on whether we dequeue or not, remove from 'S' dequeue value, add into S new value
    // 4. calculate new average
    public double Next(int val) {
        if(q.Count == k) {
            sum -= q.Dequeue();
            q.Enqueue(val);
            sum += val;
            avg = (double)sum/q.Count;
        }
        else {
            q.Enqueue(val);
            sum += val;
            avg = (double)sum/q.Count;
        }

        return avg;
    }
}

/**
 * Your MovingAverage object will be instantiated and called as such:
 * MovingAverage obj = new MovingAverage(size);
 * double param_1 = obj.Next(val);
 */
