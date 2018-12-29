// 155 E Min Stack
// Support GetMin() in O(1) time
// https://leetcode.com/problems/min-stack/description/
//

public class MinStack {

    Stack<int> mainSt, auxSt;
    /** initialize your data structure here. */
    public MinStack() {
        mainSt = new Stack<int>();
        auxSt = new Stack<int>();
    }

    public void Push(int x) {
        mainSt.Push(x);
        // first element pushed || curr element is smaller than existing min
        if(auxSt.Count == 0 || (auxSt.Count != 0 && auxSt.Peek() >= x)) {
            auxSt.Push(x);
        }
    }

    public void Pop() {
        if(mainSt.Count == 0) return;
        if(auxSt.Count != 0 && auxSt.Peek() == mainSt.Peek())
            auxSt.Pop();
        mainSt.Pop();
    }

    public int Top() {
        return mainSt.Count == 0 ? 0 : mainSt.Peek();
    }

    public int GetMin() {
        return auxSt.Count == 0 ? 0 : auxSt.Peek();
    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(x);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */
