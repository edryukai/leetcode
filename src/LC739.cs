// M 739 Find next warmer day distance 
// Logic is similar to finding next greater element, this time we need the distance (LC 496, 503)
// Note: next greater element => stack
//       element to right and greatest => BIT/SegTree/BST

public class Solution {
    public int[] DailyTemperatures(int[] T) {
        if(T == null || T.Length == 0) return null;
        
        int l = T.Length;
        int[] res = new int[l];
        var st = new Stack<int>();  // stores indices
        
        for(int i = 0; i < l; i++) {
            int curr = T[i];
            while(st.Count != 0 && T[st.Peek()] < curr) {
                res[st.Peek()] = i - st.Pop();  // store difference between indices since that's what we want
            }
            
            st.Push(i);
        }
        
        return res;
    }
}
