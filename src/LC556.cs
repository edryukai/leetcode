// 556 M Next Greater Element 3
//
// Algo:
//      1. Edge cases: 
//              > Reverse Sorted number -> output -1
//              > Sorted number -> swap last two digits
//      2. Scan from end (because we need to find smallest of all greater numbers)
//      3. Find a decreasing pattern (i.e current digit < previous digit). Call this digit 'd'
//      4. Search for the right of 'd' the smallest number that is greater than 'd', call it 'g'
//      5. Swap 'd' and 'g'
//      6. Sort all positions to right of whichever index 'd' was at
//      7. Output the number
//

public class Solution {
    public int NextGreaterElement(int n) {
        char[] num = n.ToString().ToCharArray();
        
        // 2. Scan from end
        for(int i = num.Length-1; i > 0; i--) {
            // 3. Find first decreasing pattern
            if(num[i-1] < num[i])
              break;
        }

        // This is the largest number
        if(i == 0) return -1;

        int smallest = i;
        char x = num[i-1]; 
        // 4. Search to the right of 'd' smallest number greater than d
        for(int j = i+1; j < num.Length; j++) {
            if(num[j] > x && num[j] <= num[smallest])
                smallest = j;
        }

        // 5. Swap d and g
        char temp = num[i-1]; 
        num[i-1] = num[smallest];
        num[smallest] = temp;

        // 6. Sort to right of i-1
        Arrays.Sort(num, i, num.Length);

        long val = Convert.ToInt64(new String(num));
        return val <= Int32.MaxValue ? val : -1;
    }
}
