// Repeating input integers. Each of them should have the same probability of getting picked
// 398 - M Random Pick Index
// https://leetcode.com/problems/random-pick-index/discuss/
//
// Logic:
// Say input is {1,2,3,3,3} and target to output is 3
// Each of the indices where 3 occurs (i.e 2,3,4) should have same probability of getting picked up
//
// random.nextInt(x) => picks an integer from [0,x)
// we maintain a count of how many times we're hitting our number
// so probability of picking index becomes:
//
// 2 = 1 * 1/2 * 2/3 = 1/3
// 3 = 1/2 * 2/3 = 1/3
// 4 = 1/3
//

class Solution {
    public Random rndm;

    public int Pick(int[] nums, int tgt) {
        int result = -1;
        int count = 0;

        for(int i = 0; i < nums.Length; i++) {
            if(nums[i] == tgt) {
                count++;
                if(rndm.nextInt(count) == 0) {
                    result = i;
                }
            }
        }

        return result;
    }
}
