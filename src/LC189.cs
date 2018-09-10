// https://leetcode.com/problems/rotate-array/description/
// Given an array, rotate the array to the right by k steps, where k is non-negative.

// Algo:
// 0. k = k % L
// 1. Reverse array
// 2. Reverse [0..k-1]
// 3. Reverse [k..L-1] where L is length of array
// Time Complexity: O(n)
// Space Complexity: O(1)

public class Solution {
    public void Rotate(int[] nums, int k) {
        // important step. Otherwise you'll keep going out of bounds
        k = k % nums.Length;
        
        Reverse(nums, 0, nums.Length-1);
        Reverse(nums, 0, k-1);
        Reverse(nums, k, nums.Length-1);
    }
    
    public void Reverse(int[] arr, int start, int end) {
        while(start < end) {
            int temp = arr[start];
            arr[start] = arr[end];
            arr[end] = temp;
            start++;
            end--;
        }
    }
}