class Solution {
  public int FindKthLargest(int[] nums, int k) {
    // we need kth largest
    k = nums.Length - k;
    int lo = 0, hi = nums.Length-1;

    int partition_index = 0;
    while(lo < hi) {
      partition_index = Partition(nums, lo, hi);
      
      if(partition_index < k) {
        lo = partition_index+1;
      }
      else if(partition_index > k) {
        hi = parition_index-1;
      }
      else {
        break;
      }
      // since we are manipulating original array itself, parition_index is landing at k
      return nums[k];
    }
  }

  // Parition logic:
  // 1. Pick first element as the candidate
  // 2. Scan the remaining array (from second to end) and call this range lo to hi
  // 3. We accumulate such that < cand | = cand | > cand
  // 4. After the first while loop, we are at a place where a[i] >= candidate
  // 5. After the second while loop, we are at a place where a[j] <= candidate
  // 6. So effectively, swapping a[i] with a[j] will restore our logic mentioned in #3 
  // 7. In the end, swap candidate with a[j] so that everything == candidate is in middle
  private int Partition(int[] a, int lo, int hi) {
    int candidate = a[lo];
    int i = lo+1, j = hi;

    while(true) {
      while(i < hi && a[i] < candidate) i++;
      while(j > lo && a[j] > candidate) j--;
      if(i >= j) break;
      Swap(a,i,j);
    }
    Swap(a,lo,j);
    return j;
  }

  private void Swap(int[] a, int i, int j) {
    int temp = a[i];
    a[i] = a[j];
    a[j] = temp;
  }

  private bool Less(int a, int b) {
    return a < b;
  }
}
