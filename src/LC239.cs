// 239 H Sliding Window Maximum
// Logic: Use deque. Head of deque will be the max element in window
// We keep promising elements in deque. When we encounter a greater element then we remove from tail till we find a greater element

public int[] maxSlidingWindow(int[] a, int k) {
    if(a == null || k <= 0) return new int[0];
    int l = a.length;
    int[] res = new int[n-k+1];
    int index = 0;

    Deque<Integer> q = new ArrayDeque<>();
    for(int i = 0; i < l; i++) {
        // remove numbers out of range
        while(!q.isEmpty() && q.peek() < i-k+1) {
            q.poll();
        }

        // remove smaller numbers than the one we are encountering from tail as they are not candidates
        while(!q.isEmpty() && a[q.peekLast()] < a[i]) {
            q.pollLast();
        }

        // enqueue index of greater element into queue and put result in res array
        q.offer(i);
        // so that for first two elements we don't fill res
        if(i >= k-1) {
            res[index++] = a[q.peek()];
        }
    }

    return res;
}
