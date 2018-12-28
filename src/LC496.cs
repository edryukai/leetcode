// 496 E Next Greater Element 1
// https://leetcode.com/problems/next-greater-element-i/description/
// https://leetcode.com/problems/next-greater-element-i/discuss/97595/Java-10-lines-linear-time-complexity-O(n)-with-explanation
// O(n) time
// O(n) space

public class Solution {
    public int[] NextGreaterElement(int[] findNums, int[] nums) {
        var dict = new Dictionary<int,int>(); // nums[i], nextGreater(nums[i])
        var st = new Stack<int>();
        
        // Logic: If there's a decreasing sequence followed by an increase, then the increase is the 
        //          nextGreater for all elements in the decreasing sequence
        //
        // So pop out all elements in stack if you get a greater element and record the current element as next Greater in dict
        foreach(int num in nums) {
            while(st.Count != 0 && st.Peek() < num) {
                dict[st.Pop()] = num;
            }
            st.Push(num);
        }
        
        int[] res = new int[findNums.Length];
        for(int i = 0; i < res.Length; i++) {
            if(dict.ContainsKey(findNums[i]))
                res[i] = dict[findNums[i]];
            else
                res[i] = -1;
        }
        
        return res;
    }
}
