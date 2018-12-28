// 232 E Queue using Two Stacks
// https://leetcode.com/problems/implement-queue-using-stacks/description/
//

public class MyQueue {

    public Stack<int> mainSt, auxSt;
    
    /** Initialize your data structure here. */
    public MyQueue() {
        mainSt = new Stack<int>();
        auxSt = new Stack<int>();
    }
    
    /** Push element x to the back of queue. */
    public void Push(int x) {
        mainSt.Push(x);
    }
    
    /** Removes the element from in front of queue and returns that element. */
    public int Pop() {
        return Helper(remove: true);
    }
    
    /** Get the front element. */
    public int Peek() {
        return Helper(remove: false);
    }
    
    /** Returns whether the queue is empty. */
    public bool Empty() {
        return mainSt.Count == 0;
    }
    
    private int Helper(bool remove = false) {
        // Move all elements to aux stack
        while(mainSt.Count != 0) {
            auxSt.Push(mainSt.Pop());
        }
        
        // peek/pop reqd element
        int res = remove ? auxSt.Pop() : auxSt.Peek();
        
        // move remaining elements back to main stack
        while(auxSt.Count != 0) {
            mainSt.Push(auxSt.Pop());
        }
        
        return res;
    }
}

/**
 * Your MyQueue object will be instantiated and called as such:
 * MyQueue obj = new MyQueue();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Peek();
 * bool param_4 = obj.Empty();
 */
