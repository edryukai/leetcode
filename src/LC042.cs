// H 042 Trapping Rain Water 1 (1D)
// Logic:
//      - Amount of water trapped above each block is determined by Min(max_ht_to_left, max_ht_to_rt) - current_ht
//      - Naive way of doing: maintain two arrays for max_left, max_right and do the above computation, but it takes O(n) space
//      - Efficient way: maintain two pointers left and right, two heights leftMax and rightMax and update contributions and leftMax and rightMax accordingly
//

public class Solution {
    public int Trap(int[] height) {
        if(height == null || height.Length == 0)
            return 0;

        int l = height.Length;
        int left = 0, right = l-1;
        int leftmax = 0, rightmax = 0;
        int ans = 0;

        while(left < right) {
            // Contribution coming from left side
            if(height[left] < height[right])
            {
                // if current block responsible for max height, its contribution water is 0
                leftmax = Math.Max(leftmax, height[left]);
                ans += (leftmax - height[left]);
                left++;
            }
            else
            {
                rightmax = Math.Max(rightmax, height[right]);
                ans += (rightmax - height[right]);
                right--;
            }
        }

        return ans;
    }
}
