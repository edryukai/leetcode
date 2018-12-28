// 503 M Next Greater Element 2
// https://leetcode.com/problems/next-greater-element-ii/description/
//
// Difference is here we have a circular array, so it's like concatenating nums with nums
// So we gotta search it twice
//
// In Next Greater Element 1, we maintained the elements that are lesser in a stack and popped them out once we got a greater one
// In the current solution,
//    We will maintain indices of elements lesser than current element in stack
//    When we find a greater element we pop all those indices and update result array with current element for those indices
//
// Space: O(n)
// Time: O(n)
//
// Useful template: https://leetcode.com/problems/next-greater-element-ii/discuss/98262/Typical-ways-to-solve-circular-array-problems.-Java-solution.
//
public class Solution {
    public int[] nextGreaterElements(int[] nums) {
        int n = nums.Length;
        int[] res = new int[n];
        var st = new Stack<int>();

        // fill -1 in res
        for(int i = 0; i < n; i++)  res[i] = -1;

        for(int i = 0; i < 2*n; i++) {
            int curr = nums[i % n];
            while(st.Count != 0 && nums[st.Peek()] < curr) {
                res[st.Pop()] = curr;
            }
            st.Push(i % n);
        }

        return res;
    }
}
